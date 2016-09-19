<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/08/2016
 * Time: 01:09
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['name'])&& isset($_POST['local_path'])&& isset($_POST['modpack_name'])&&
    isset($_POST['ip'])&& isset($_POST['port'])&& isset($_POST['game'])&& isset($_POST['rank']) && isset($_POST['teamspeak']) &&
    isset($_POST['website']) && isset($_POST['id']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];
    $name = $_POST['name'];
    $local_path = $_POST['local_path'];
    $modpack_name = $_POST['modpack_name'];
    $ip = $_POST['ip'];
    $port = $_POST['port'];
    $game = $_POST['game'];
    $rank = $_POST['rank'];
    $teamspeak = $_POST['teamspeak'];
    $website = $_POST['website'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 9  && (int)$res['banned'] != 1)
        {

            $getServer = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
            $getServer->execute(array('id' => $id));
            if ($getServer->rowCount() != 0)
            {
                $getSettings = $database->prepare('UPDATE `servers` SET `name`= :name,`local_path`= :local_path,`modpack_name`= :modpack_name,
                                                  `ip`= :ip,`port`= :port,`teamspeak`= :teamspeak,`website`= :website,`game`= :game,
                                                  `rank`= :rank WHERE id= :id');
                $getSettings->execute(array('name' => $name, 'local_path' => $local_path, 'modpack_name' => $modpack_name, 'ip' => $ip,
                    'port' => $port, 'game' => $game, 'rank' => $rank, 'teamspeak' => $teamspeak, 'website' => $website, 'id' => $id));
                $result['status'] = 42;
                $result['message'] = "Server saved";
            }
            else
            {
                $result['status'] = 404;
                $result['message'] = "Server not found";
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