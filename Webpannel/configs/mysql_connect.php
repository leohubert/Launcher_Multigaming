<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 22:47
 */

try {
    $database = new PDO('mysql:host='. $mysql_host .';dbname='. $mysql_dbname, $mysql_user, $mysql_pass);
} catch (PDOException $e) {
    print "Erreur !: " . $e->getMessage() . "<br/>";
    die();
}

if ($ig_info == true)
{
    try {
        $db_arma = new PDO('mysql:host='. $db_arma_host .';dbname='. $db_arma_name, $db_arma_user, $db_arma_pass);
    } catch (PDOException $e) {
        print "Erreur !: " . $e->getMessage() . "<br/>";
        die();
    }
}
