<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && isset($_POST['email']) && isset($_POST['username']) && isset($_POST['banned']) && isset($_POST['level']) && isset($_POST['picture']) && isset($_POST['uid']) &&
    is_numeric($_POST['level']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];
    $email = $_POST['email'];
    $username = $_POST['username'];
    $banned = $_POST['banned'];
    $level = $_POST['level'];
    $picture = $_POST['picture'];
    $uid = $_POST['uid'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ((int)$my['level'] >= 8 && (int)$my['banned'] != 1)
        {
            if ($getSettings = $database->prepare('SELECT * FROM `users` WHERE id=:id'))
            {
                $getSettings->execute(array('id' => $id));
                if ($getSettings->rowCount() != 0)
                {
                    $user = $getSettings->fetch();
                    if (((int)$my['level'] > (int)$user['level'] && (int)$level < (int)$my['level']) || (int)$my['level'] >= 9)
                    {
                        $saveUser = $database->prepare('UPDATE `users` SET `email`=:email,`username`=:username,`banned`=:banned,`level`=:level,`picture`=:picture,`uid`=:uid WHERE id=:id');
                        $saveUser->execute(array('email' => $email, 'username' => $username, 'banned' => $banned, 'level' => $level, 'picture' => $picture, 'uid' => $uid, 'id' => $id));
                        $result['status'] = 42;
                        $result['message'] = "User successfully saved";
                    }
                    else
                    {
                        $result['status'] = 44;
                        $result['message'] = "You don't have right to create this request !";
                    }
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
