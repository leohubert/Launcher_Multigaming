<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 10/04/2016
 * Time: 00:41
 */

/** MySql Info */

$db_host = "localhost";
$db_user = "root";
$db_pass = "root";
$db_name = "launcher_old";

/** Basic config */

$siteName = "NomDeTeam";
$apiUrl = "http://localhost:8000/API/";

function troll_token()
{
    return bin2hex(base64_encode(md5(sha1(openssl_random_pseudo_bytes(16)))));
};


