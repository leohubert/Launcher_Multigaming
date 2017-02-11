<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userInfo = $database->prepare('SELECT * FROM users WHERE id = :id')) {
        $userInfo->execute(array('id' => $res['user_id']));
        $res = $userInfo->fetch();
        if ($userInfo->rowCount() != 0) {
                $result['status'] = 42;
                $result['message'] = "Result successfully showed";
                $result['username'] = $res['username'];
                $result['email'] = $res['email'];
                $result['registered'] = $res['registered'];
                $result['banned'] = $res['banned'];
                $result['level'] = $res['level'];
                $result['uid'] = $res['uid'];
                $result['last_ip'] = $res['last_ip'];
                $result['picture'] = $res['picture'];
        }
        else
        {
            $result['status'] = 01;
            $result['message'] = "User not found";
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
