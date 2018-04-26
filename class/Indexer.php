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
    private $version = 'v5.4-beta.2-auto-updater';

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

        $this->client = new RestClient([
            'base_url' => $this->api
        ]);
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
}