<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if ($getSettings = $database->prepare('SELECT * FROM `users` WHERE last_connection > (:date)'))
{
    $getSettings->execute(array('date' => date('Y-m-d H:i:s', strtotime('-1 week'))));
    $result['status'] = 42;
    $result['message'] = "Result successfully showed";
    $result['total_7days'] = $getSettings->rowCount();
    $allUsers = $database->prepare('SELECT id FROM `users`');
    $allUsers->execute();
    $result['nbUsers'] = $allUsers->rowCount();
    $getNewsUsers = $database->prepare('SELECT * FROM `users` WHERE registered > (:date)');
    $getNewsUsers->execute(array('date' => date('Y-m-d H:i:s', strtotime('-1 week'))));
    $result['total_new7days'] = $getNewsUsers->rowCount();
    $getNewsUsers = $database->prepare('SELECT * FROM `users` WHERE level >= 6');
    $getNewsUsers->execute();
    $result['nbAdmins'] = $getNewsUsers->rowCount();
}

echo json_encode($result);