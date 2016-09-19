<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 11/07/2016
 * Time: 22:26
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if ($getSettings = $database->prepare('SELECT * FROM `servers` ORDER BY `rank` ASC'))
{
    $getSettings->execute();
    $result['status'] = 42;
    $result['message'] = "Servers listed";
    $result['total'] = $getSettings->rowCount();
    $result['servers'] = array();
    $i = 0;
    while ($res = $getSettings->fetch())
    {
        $result['servers'][$i]['id'] = (int)$res['id'];
        $result['servers'][$i]['name'] = $res['name'];
        $result['servers'][$i]['ip'] = $res['ip'];
        $result['servers'][$i]['port'] = $res['port'];
        $result['servers'][$i]['show_infos'] = (int)$res['show_infos'];
        $result['servers'][$i]['teamspeak'] = $res['teamspeak'];
        $result['servers'][$i]['website'] = $res['website'];
        $result['servers'][$i]['game'] = $res['game'];
        $result['servers'][$i]['maintenance'] = $res['maintenance'];
        $result['servers'][$i]['lock'] = $res['lock'];
        $i++;
    }
}

echo json_encode($result);