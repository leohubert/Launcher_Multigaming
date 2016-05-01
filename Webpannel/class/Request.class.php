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