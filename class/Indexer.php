<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 08/04/2018
 * Time: 02:06
 */

include './class/RestClient.php';

class Indexer
{
    private $api = 'http://indexer.emodyz.eu/api';
    private $urltest = 'http://indexer.emodyz.eu';
    private $devApi = 'http://v5-indexer.test/api';
    private $version = 'v5.4-beta.2-last';

    private $database;
    private $name;
    private $analytics;
    private $currentUrl;

    private $client = null;
    public function __construct($name, $analytics, $database)
    {
        $this->name = $name;
        $this->analytics = $analytics;
        $this->database = $database;

        $this->currentUrl = (isset($_SERVER['HTTPS']) ? "https" : "http") . "://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";


        if (strstr($this->currentUrl, "v5-webpanel.test")) {
            $this->api = $this->devApi;
        }

        $this->client = new RestClient([
            'base_url' => $this->api
        ]);
    }

    public function askRun()
    {
        $url = $this->urltest;
        // Check, if a valid url is provided
        if(!filter_var($url, FILTER_VALIDATE_URL)){
            return false;
        }

        // Initialize cURL
        $curlInit = curl_init($url);
    
        // Set options
        curl_setopt($curlInit,CURLOPT_CONNECTTIMEOUT,4);
        curl_setopt($curlInit,CURLOPT_HEADER,true);
        curl_setopt($curlInit,CURLOPT_NOBODY,true);
        curl_setopt($curlInit,CURLOPT_RETURNTRANSFER,true);

        // Get response
        $response = curl_exec($curlInit);
    
        // Close a cURL session
        curl_close($curlInit);

        return $response?true:false;
    }

    public function registerApp()
    {
        $result = $this->client->post('/servers', [
            'address' => $this->currentUrl,
            'name' => $this->name,
            'version' => $this->version
        ]);

        if($result->info->http_code == 200)
            return true;
        else
            return false;
    }

    public function sendAnalytics()
    {
        $nbUsers = $this->database->query('SELECT COUNT(*) AS total FROM users WHERE 1')->fetchColumn();
        $nbServers = $this->database->query('SELECT COUNT(*) AS total FROM servers WHERE 1')->fetchColumn();

        $result = $this->client->post('/servers', [
            'address' => $this->currentUrl,
            'name' => $this->name,
            'nb_users' => (int)$nbUsers,
            'nb_servers' => (int)$nbServers,
            'version' => $this->version
        ]);

        if($result->info->http_code == 200)
            return true;
        else
            return false;
    }

    public function getToken()
    {
        $result = $this->client->post('/sessions');

        if($result->info->http_code == 200) {
            $result->decode_response();
            if ($result->decoded_response->token) {
                header('Location: ' . $this->api . '/sessions/login?token='. $result->decoded_response->token);
            }
            return true;
        }
        else
            return false;
    }

    public function installFinished($analytics)
    {
        $result = $this->client->put('/servers', [
            'address' => $this->currentUrl,
            'finished' => 1,
            'analytics' => $analytics == true ? 1 : 0
        ]);

        if($result->info->http_code == 200)
            return true;
        else
            return false;
    }

    /**
     * Check if an ip is whitelisted for support
     *
     * @param string $ip
     * @return bool
     */
    public function checkIp($ip)
    {
        $result = $this->client->get('/tools/whitelist/check', [
            'ip' => $ip
        ]);

        if($result->info->http_code == 200)
            return true;
        else
            return false;

    }
}
