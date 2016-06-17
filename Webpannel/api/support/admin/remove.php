<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
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
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 8  && $res['banned'] != 1)
        {
            $getSettings = $database->prepare('SELECT id FROM `support` WHERE id=:id');
            $getSettings->execute(array('id' => $id));
            if ($getSettings->rowCount() != 0) {
                if ($getSettings = $database->prepare('DELETE FROM `support` WHERE id = :id')) {
                    $getSettings->execute(array('id' => $id));
                    $getSettings = $database->prepare('DELETE FROM `support_conversation` WHERE support_id = :id'); 
                    $getSettings->execute(array('id' => $id));
                    $result['status'] = 42;
                    $result['message'] = "Chat removed";
                }
            }
            else
            {
                $result['status'] = 40;
                $result['message'] = "Conversation do not exist.";
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