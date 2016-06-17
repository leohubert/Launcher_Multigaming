<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 13/06/16
 * Time: 23:53
 */

/** ENCRYPTION CONFIG */

$encrypt_key = "DVfu0om9h1Dw7O45GvOLY7WOmQTKA4X9";

/** @var Config general $site */

$site = "Your server name";

/**
 * Config Arma
 *
 * For active Arma server stats make:
 *      $armaStats = true;
 * else make
 *      $armaStats = false;
 *
 */

$armaState = false;

/** if "$armaState = false;" you can leave empty these fields  */

$arma_ip = "null";
$arma_port = "null";
$arma_servername = "null";


/** MYSQL INCLUDE */

include_once "config_mysql.php";

try {
    $database = new PDO('mysql:host='. $mysql_ip .';dbname='. $mysql_dbname, $mysql_user, $mysql_pass);
} catch (PDOException $e) {
    print "Erreur !: " . $e->getMessage() . "<br/>";
    die();
}
