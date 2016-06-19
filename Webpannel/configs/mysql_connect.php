<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 22:47
 */

try {
    $database = new PDO('mysql:host='. $mysql_ip .';dbname='. $mysql_dbname, $mysql_user, $mysql_pass);
} catch (PDOException $e) {
    print "Erreur !: " . $e->getMessage() . "<br/>";
    die();
}