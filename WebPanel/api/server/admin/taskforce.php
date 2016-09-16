<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/08/2016
 * Time: 02:40
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && is_numeric($_POST['id']) && isset($_POST['taskforce']) && is_numeric($_POST['taskforce']) )
{
    $token = $_POST['token'];
    $id = $_POST['id'];
    $taskforce = (int)$_POST['taskforce'];

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
            $getSettings = $database->prepare('UPDATE servers SET `taskforce` = :taskforce WHERE id=:id');
            $getSettings->execute(array('id' => $id, 'taskforce' => $taskforce));
            $result['status'] = 42;
            if ($taskforce == 1)
                $result['message'] = "Taskforce Enabled";
            else
                $result['message'] = "Taskforce Disabled";
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