<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && isset($_POST['email']) && isset($_POST['picture']) && isset($_POST['uid']))
{
    $token = $_POST['token'];
    $email = $_POST['email'];
    $picture = $_POST['picture'];
    $uid = $_POST['uid'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $id = $res['user_id'];
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ((int)$my['level'] != 0 && (int)$my['banned'] != 1)
        {
            $saveUser = $database->prepare('UPDATE `users` SET `email`=:email, `picture`=:picture,`uid`=:uid WHERE id=:id');
            $saveUser->execute(array('email' => $email, 'picture' => $picture, 'uid' => $uid, 'id' => $id));
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
