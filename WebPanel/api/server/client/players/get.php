<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 29/06/2016
 * Time: 10:25
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && is_numeric($_POST['id']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];

    $getSettings = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
    $getSettings->execute(array('id' => $id));
    $res = $getSettings->fetch();

    if ($res['show_infos'] == 0)
    {
        $result['status'] = 24;
        $result['message'] = "Stats disabled";
        echo json_encode($result);
        exit();
    }

    $encrypter = new Encryption($encrypt_key);

    $custom_host = $encrypter->decode($res['db_host']);
    $custom_name = $encrypter->decode($res['db_name']);
    $custom_user = $encrypter->decode($res['db_user']);
    $custom_pass = $encrypter->decode($res['db_pass']);

    $db_ok = true;
    try {
        $custom_db = new PDO('mysql:host='. $custom_host .';dbname='. $custom_name, $custom_user, $custom_pass);
    } catch (PDOException $e) {
        $db_ok = false;
    }

    if ($db_ok == true)
    {
        $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
        $checkUser->execute(array('token' => $token));
        $res = $checkUser->fetch();
        if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`,`uid` FROM users WHERE id = :id'))
        {
            $userLevel->execute(array('id' => $res['user_id']));
            $myID = $res['user_id'];
            $res = $userLevel->fetch();
            $id = $res['uid'];
            if ($userLevel->rowCount() != 0 && (int)$res['banned'] != 1)
            {

                $getPlayerInfo = $custom_db->prepare('SELECT * FROM `players` WHERE playerid=:id');
                $getPlayerInfo->execute(array('id' => $id));
                $player = $getPlayerInfo->fetch();
                if ($getPlayerInfo->rowCount() != 0) {
                    $result['name'] = $player['name'];
                    $result['cash'] = $player['cash'];
                    $result['bank'] = $player['bankacc'];
                    $result['coplevel'] = $player['coplevel'];
                    $result['mediclevel'] = $player['mediclevel'];
                    $result['adminlevel'] = $player['adminlevel'];
                    $result['status'] = 42;
                    $result['message'] = "User successfully showed";
                }
                else
                {
                    $result['status'] = 40;
                    $result['message'] = "User do not exits.";
                }
            }
            else
            {
                $result['status'] = 44;
                $result['message'] = "You don't have right to create this request !";
            }
        }
        else
        {
            $result['status'] = 41;
            $result['message'] = "Token invalid";
        }
    }
    else
    {

        $result['status'] = 15;
        $result['message'] = "DB not good";

    }

}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);