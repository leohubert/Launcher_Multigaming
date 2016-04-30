<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 30/04/2016
 * Time: 19:33
 */

include_once ("../config/config.php");

if (isset($_POST['action']))
{
    switch ($_POST['action'])
    {
        case "logIn":
            $session = new Session($apiUrl);
            $session->start();
            $session->logIn();
            break;
    }
}

if (isset($_GET['action']))
{
    switch ($_GET['action'])
    {
        case "logOut":
            $session = new Session($apiUrl);
            $session->start();
            $session->logOut();
            break;
    }
}

class Session
{
    public static $_sessionStarted = false;
    public static $_apiUrl;

    function __construct($apiUrl)
    {
        self::$_apiUrl = $apiUrl;
    }

    public static function start()
    {
        session_start();
        self::$_sessionStarted = true;
    }

    public static function logIn()
    {
        if (isset($_POST['login']) && isset($_POST['password']) && self::$_sessionStarted == true) {

            /** @var Init request fields $fields */
            $fields = array(
                'login' => urlencode($_POST['login']),
                'password' => urlencode($_POST['password'])
            );

            /** @var Lanch request $json */
            $json = self::request(self::$_apiUrl . "login.php", $fields);

            /** Check status request response */
            if ($json->{'status'} == "42" && $json->{'grade'} != "0")
            {
                $_SESSION['email'] = $json->{'email'};
                $_SESSION['username'] = $json->{'username'};
            }
            header ("location: ../panel");
            exit();
        }
    }

    public static function logOut()
    {
        if (self::$_sessionStarted == true)
        {
            session_destroy();
            header ("location: ../panel/login.php");
            exit;
        }
    }

    function request($url, $fields)
    {
        $fields_string = "";

        //url-ify the data for the POST
        foreach($fields as $key=>$value) { $fields_string .= $key.'='.$value.'&'; }
        rtrim($fields_string, '&');

        //open connection
        $ch = curl_init();

        //set the url, number of POST vars, POST data
        curl_setopt($ch,CURLOPT_URL, $url);
        curl_setopt($ch,CURLOPT_POST, count($fields));
        curl_setopt($ch,CURLOPT_POSTFIELDS, $fields_string);
        curl_setopt($ch,CURLOPT_RETURNTRANSFER, true);

        //execute post
        $result = curl_exec($ch);
        return (json_decode($result));
    }
}