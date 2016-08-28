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
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 6  && (int)$res['banned'] != 1)
        {
            $getSettings = $database->prepare('SELECT * FROM `news` WHERE id=:id');
            $getSettings->execute(array('id' => $id));
            $news = $getSettings->fetch();
            if ($getSettings->rowCount() != 0) {
                $result['title'] = $news['title'];
                $result['date'] = $news['date'];
                $result['link'] = $news['link'];
                $result['status'] = 42;
                $result['message'] = "News successfully showed";
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