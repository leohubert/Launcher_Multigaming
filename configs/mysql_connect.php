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
    $result = ['status' => 500, 'message' => 'Error, DB config: '. $e->getMessage() . ' '];
    echo json_encode($result);
    die();
}