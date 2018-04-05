<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/08/2016
 * Time: 01:09
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['name']) && isset($_POST['modpack_name'])&&
    isset($_POST['ip'])&& isset($_POST['port'])&& isset($_POST['game'])&& isset($_POST['rank']))
{
    $token = $_POST['token'];
    $name = $_POST['name'];
    $local_path = 'games/' . strtolower($_POST['name']);
    $modpack_name = $_POST['modpack_name'];
    $ip = $_POST['ip'];
    $port = $_POST['port'];
    $game = $_POST['game'];
    $rank = $_POST['rank'];

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
            //Create directory
            $allOK = true;
            if (!file_exists($local_path))
            {
                if (!mkdir($local_path, 0777, true)) {
                    $allOK = false;
                }
            }

            if (!file_exists($local_path . '/modpack'))
            {
                if (!mkdir($local_path . '/modpack', 0777, true)) {
                    $allOK = false;
                }
            }

            if (!file_exists($local_path . '/modpack/addons'))
            {
                if (!mkdir($local_path . '/modpack/addons', 0777, true)) {
                    $allOK = false;
                }
            }

            if (!file_exists($local_path . '/taskforce'))
            {
                if (!mkdir($local_path . '/taskforce', 0777, true)) {
                    $allOK = false;
                }
            }

            if (!file_exists($local_path . '/userconfig'))
            {
                if (!mkdir($local_path . '/userconfig', 0777, true)) {
                    $allOK = false;
                }
            }




            if ($allOK == false) {
                $result['status'] = 18;
                $result['message'] = "Can't create directory, verify your local path and permission (777) ";
            }
            else
            {
                $getSettings = $database->prepare('INSERT INTO `servers`(`name`, `local_path`, `modpack_name`, `ip`, `port`, `game`, `rank`) 
                                               VALUES (:name, :local_path, :modpack_name, :ip, :port, :game, :rank)');
                $getSettings->execute(array('name' => $name, 'local_path' => $local_path, 'modpack_name' => $modpack_name, 'ip' => $ip,
                    'port' => $port, 'game' => $game, 'rank' => $rank));
                $result['status'] = 42;
                $result['message'] = "Server created";
                $result['server_id'] = $database->lastInsertId();
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