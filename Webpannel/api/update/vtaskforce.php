<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 13:14
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['vtaskforce']))
{
    $token = $_POST['token'];
    $vtaskforce = $_POST['vtaskforce'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 9  && (int)$res['banned'] != 1)
        {
            $insertToken = $database->prepare('UPDATE settings SET vtaskforce=:vtaskforce WHERE active = 1');
            $insertToken->execute(array('vtaskforce' => $vtaskforce));
            $result['status'] = 42;
            $result['message'] = "New taskforce update created";
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