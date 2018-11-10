<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 03:19
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if ($getSettings = $database->prepare('SELECT * FROM settings WHERE active = 1'))
{
    $getSettings->execute();
    $res = $getSettings->fetch();
    $result['status'] = 42;
    $result['message'] = "Result successfully showed";
    $result['msg_title'] = $res['msg_title'];
    $result['msg_content'] = $res['msg_content'];
    $result['maintenance'] = (int)$res['maintenance'];
    $result['maintenance_title'] = $res['maintenance_title'];
    $result['maintenance_content'] = $res['maintenance_content'];
    $result['login'] = (int)$res['login'];
    $result['register'] = (int)$res['register'];
    $result['indexer'] = (int)$res['indexer'];
    $result['uuid'] = (int)$res['uuid'];
    if (file_exists('games/launcher/launcher.exe'))
    {
        $result['vlauncher'] = md5_file('games/launcher/launcher.exe');
    }
    else
    {
        $result['vlauncher'] = "FileNotFound";
    }

}

echo json_encode($result);
