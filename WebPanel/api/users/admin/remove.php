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
            if ((int)$my['level'] >= 8 && (int)$my['banned'] != 1)
            {
                $getSettings = $database->prepare('DELETE FROM `users` WHERE id=:id');
                $getSettings->execute(array('id' => $id));
                $result['status'] = 42;
                $result['message'] = "User successfully deleted";
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
