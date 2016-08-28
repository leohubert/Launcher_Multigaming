<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 29/06/2016
 * Time: 10:25
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if ($ig_info == false)
{
    $result['status'] = 24;
    $result['message'] = "Stats disabled";
    echo json_encode($result);
    exit();
}
if (isset($_POST['token']) && isset($_POST['uid']))
{
    $token = $_POST['token'];
    $uid = $_POST['uid'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 7  && (int)$res['banned'] != 1)
        {
            $getPlayerInfo = $db_arma->prepare('SELECT * FROM `players` WHERE playerid=:id');
            $getPlayerInfo->execute(array('id' => $uid));
            $player = $getPlayerInfo->fetch();
            if ($getPlayerInfo->rowCount() != 0) {
                $result['name'] = $player['name'];
                $result['cash'] = $player['cash'];
                $result['bank'] = $player['bankacc'];
                $result['coplevel'] = $player['coplevel'];
                $result['mediclevel'] = $player['mediclevel'];
                $result['adminlevel'] = $player['adminlevel'];
                $result['status'] = 42;
                $result['message'] = "User successfully showed.";
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
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);