<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/08/2016
 * Time: 01:09
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && is_numeric($_POST['id']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 6  && (int)$res['banned'] != 1)
        {
            $myLevel = (int)$res['level'];
            $getSettings = $database->prepare('SELECT * FROM `servers` WHERE id=:id');
            $getSettings->execute(array('id' => $id));
            $res = $getSettings->fetch();
            if ($getSettings->rowCount() != 0) {
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
                if ($res['password'] == 'null')
                    $result['haspass'] = 0;
                else
                    $result['haspass'] = 1;
                if ($res['lock'] == 'null')
                    $result['locked'] = 0;
                else
                    $result['locked'] = 1;
                if ($myLevel >= 9)
                {
                    if ($res['lock'] == 'null')
                        $result['lock'] = "No password";
                    else
                        $result['lock'] = $res['lock'];
                }
                else
                {
                    if ($res['lock'] == 'null')
                        $result['lock'] = "No password";
                    else
                        $result['lock'] = "*******";
                }
                if ($myLevel >= 9)
                {
                    if ($res['password'] == 'null')
                        $result['password'] = "No password";
                    else
                        $result['password'] = $res['password'];
                }
                else
                {
                    if ($res['password'] == 'null')
                        $result['password'] = "No password";
                    else
                        $result['password'] = "*******";
                }
                $result['rank'] = $res['rank'];
            }
            else
            {
                $result['status'] = 40;
                $result['message'] = "News do not exist.";
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