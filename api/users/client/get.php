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
        $checkBanIP = $database->prepare('SELECT id FROM users WHERE banned=1 AND last_ip=:ip');
        $checkBanIP->execute(array('ip' => $res['last_ip']));
        $checkBanUID = $database->prepare('SELECT id FROM users WHERE banned=1 AND uid=:uid');
        $checkBanUID->execute(array('uid' => $res['uid']));
        if ($checkBanIP->rowCount() == 0 && $checkBanUID->rowCount() == 0 && (int)$res['banned'] == 0) {
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
                $result['message'] = "Invalid credential";
            }
        } else {
            $result['status'] = 43;
            $result['message'] = "You are banned";
        }
    }
    else
    {
        $result['status'] = 41;
        $result['message'] = "Session timeout";
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);
