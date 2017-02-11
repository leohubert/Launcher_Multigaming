<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 20/09/2016
 * Time: 09:11
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`,`password` FROM users WHERE id = :id'))
    {
        $id = $res['user_id'];
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ((int)$my['level'] != 0 && (int)$my['banned'] != 1)
        {
            $request = $database->prepare('UPDATE `users` SET `last_notif`=CURRENT_TIMESTAMP WHERE id= :id');
            $request->execute(array('id' => $id));
            $result['status'] = 42;
            $result['message'] = "All notification reads";
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
