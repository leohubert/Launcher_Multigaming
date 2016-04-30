<?php
/**
 * Created by PhpStorm.
 * User: leohu
 * Date: 30/04/2016
 * Time: 20:23
 */

include "../config/config.php";

/** MySql connexion */

try {
    $db_trak = new PDO("mysql:host=$db_host;dbname=$db_name", $db_user, $db_pass);
    $db_trak->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Connection failed: " . $e->getMessage();
    die;
}