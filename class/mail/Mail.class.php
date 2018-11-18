<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 17-11-18
 * Time: 23:47
 */

include dirname(__FILE__) . 'Exception.class.php';
include dirname(__FILE__) . 'Phpmailer.class.php';
include dirname(__FILE__) . 'Smtp.class.php';

class Mail{

    private $database;
    private $config;
    private $email;
    private $from;
    private $to;
    private $type;
    private $content;


    public function __construct($database){

        $this->database = $database;
        $this->config = new Config($this->database);
        $this->email = new PHPMailer(true);

    }

    private function exeConfig(){

        $gconf = json_decode($this->getConfig());

        $dcryptnow = new Encryption($GLOBALS['key1'], $GLOBALS['key2']);
        $uncrypt = $dcryptnow->decode($gconf->password);
        $gconf->password = $uncrypt;

        $this->email->SMTPDebug = 2;
        $this->email->isSMTP();
        $this->email->Host = $gconf->host;
        $this->email->SMTPAuth = true;
        $this->email->Username = $gconf->username;
        $this->email->Password = $gconf->password;
        $this->email->SMTPSecure = $gconf->secure;
        $this->email->Port = $gconf->port;
        $this->email->isHTML(true);

    }

    private function getConfig(){

        $res = array(
            'host' => $this->config->get('mail_host'),
            'username' => $this->config->get('mail_username'),
            'password' => $this->config->get('mail_password'),
            'secure' => $this->config->get('mail_secure'),
            'port' => $this->config->get('mail_port'),
        );

        return json_encode($res);


    }

}