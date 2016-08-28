<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 12/07/2016
 * Time: 15:10
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['id']))
{
    $id = $_POST['id'];

    if ($getSettings = $database->prepare('SELECT * FROM `servers` WHERE id = :id'))
    {
        $getSettings->execute(array('id' => $id));
        $res = $getSettings->fetch();
        $result['status'] = 42;
        $result['message'] = "Servers listed";
        $result['id'] = (int)$res['id'];
        $result['name'] = $res['name'];
        $result['ip'] = $res['ip'];
        $result['port'] = $res['port'];
        $result['show_infos'] = (int)$res['show_infos'];
        $result['teamspeak'] = $res['teamspeak'];
        $result['website'] = $res['website'];
        $result['game'] = $res['game'];
        $result['taskforce'] = $res['taskforce'];
        $result['vtaskforce'] = $res['vtaskforce'];
        $result['vmod'] = $res['vmod'];
        $result['modpack_name'] = $res['modpack_name'];
        $result['local_path'] = $res['local_path'];
        $result['maintenance'] = $res['maintenance'];
        $result['can_play'] = $res['can_play'];
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);