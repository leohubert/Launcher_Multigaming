<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
            if ((int)$my['level'] >= 6 && (int)$my['banned'] != 1)
            {
                if ($getSettings = $database->prepare('SELECT * FROM `users` WHERE id=:id'))
                {
                    $getSettings->execute(array('id' => $id));
                    if ($getSettings->rowCount() != 0)
                    {
                        $res = $getSettings->fetch();
                        $result['status'] = 42;
                        $result['message'] = "Result successfully showed";
                        $result['user_username'] = $res['username'];
                        $result['user_email'] = $res['email'];
                        $result['user_registered'] = $res['registered'];
                        $result['user_banned'] = $res['banned'];
                        $result['user_level'] = $res['level'];
                        $result['user_uid'] = $res['uid'];
                        if ((int)$my['level'] >= 8)
                            $result['user_last_ip'] = $res['last_ip'];
                        else
                            $result['user_last_ip'] = "Hided";
                        $result['user_picture'] = $res['picture'];
                    }
                    else
                    {
                        $result['status'] = 01;
                        $result['message'] = "User not found";
                    }
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
