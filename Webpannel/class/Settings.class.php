<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/05/2016
 * Time: 01:32
 */

include_once "../config/config.php";
include_once "../API/mysql.php";
require_once "../class/Session.class.php";

Session::start();

if (!isset($_SESSION['username']))
{
    header ("location: /");
    exit;
}

if (isset($_GET['action'])) {
    switch ($_GET['action']) {
        case "swithMaintenance":
            switchMaintenance($apiUrl, $db_trak);
            break;
        case "switchLogin":
            switchLogin($apiUrl, $db_trak);
            break;
        case "maintenanceMsg":
            maintenanceMsg($db_trak);
            break;
        case "swithNews":
            switchNews($apiUrl, $db_trak);
            break;
        case "newsMsg":
            newsMsg($db_trak);
            break;
    }
}

function switchMaintenance($apiUrl, $db_trak)
{
    /** @var Init request fields $fields */
    $fields = array();

    /** @var Lanch request $json */
    $json = request($apiUrl . "options.php", $fields);

    /** Check status request response */
    if ($json->{'maintenance'} == "1")
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `maintenance`=0');
        $requete->execute();
    }
    else
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `maintenance`=1');
        $requete->execute();
    }
}

function maintenanceMsg($db_trak)
{
    $requete = $db_trak->prepare('UPDATE `options` SET `maintenance_msg`= :msg');
    $requete->bindParam(':msg', $_GET['msg'], PDO::PARAM_STR);
    $requete->execute();
}

function switchLogin($apiUrl, $db_trak)
{
    /** @var Init request fields $fields */
    $fields = array();

    /** @var Lanch request $json */
    $json = request($apiUrl . "options.php", $fields);

    /** Check status request response */
    if ($json->{'login'} == "1")
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `login`=0');
        $requete->execute();
    }
    else
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `login`=1');
        $requete->execute();
    }
}


function switchNews($apiUrl, $db_trak)
{
    /** @var Init request fields $fields */
    $fields = array();

    /** @var Lanch request $json */
    $json = request($apiUrl . "options.php", $fields);

    /** Check status request response */
    if ($json->{'news'} == "1")
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `news`=0');
        $requete->execute();
    }
    else
    {
        $requete = $db_trak->prepare('UPDATE `options` SET `news`=1');
        $requete->execute();
    }
}

function newsMsg($db_trak)
{
    $requete = $db_trak->prepare('UPDATE `options` SET `news_msg`= :msg');
    $requete->bindParam(':msg', $_GET['msg'], PDO::PARAM_STR);
    $requete->execute();
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