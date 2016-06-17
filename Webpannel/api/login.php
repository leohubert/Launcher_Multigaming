<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 01:26
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['login']) && isset($_POST['password']) && isset($_POST['launcher']))
{
    $login = $_POST['login'];
    $password = $_POST['password'];

    if ($checkUser = $database->prepare('SELECT * FROM users WHERE username = :login OR email = :login'))
    {
        $checkUser->execute(array('login' => $login));
        $res = $checkUser->fetch();
        $password_encrypted = new Encryption($encrypt_key);
        $password_encrypted = $password_encrypted->encode($password);
        if ($checkUser->rowCount() != 0)
        {
            if ($res['password'] == $password_encrypted)
            {
                if ($res['banned'] == '0')
                {
                    $token = md5(uniqid($login, true));
                    $checkToken = $database->prepare('SELECT token FROM sessions WHERE user_id = :user_id');
                    $checkToken->execute(array('user_id' => $res['id']));
                    if ($checkToken->rowCount() == 0) {
                        $insertToken = $database->prepare('INSERT INTO `sessions`(`token`, `user_id`) VALUES (:token, :user_id)');
                        $insertToken->execute(array('token' => $token, 'user_id' => $res['id']));
                    } else {
                        $insertToken = $database->prepare('UPDATE sessions SET token=:token WHERE user_id=:user_id');
                        $insertToken->execute(array('token' => $token, 'user_id' => $res['id']));
                    }
                    $ip = $_SERVER['REMOTE_ADDR'];
                    if (filter_var($ip, FILTER_VALIDATE_IP)) {
                        $updateIp = $database->prepare('UPDATE users SET last_ip=:ip WHERE id=:user_id');
                        $updateIp->execute(array('ip' => $ip, 'user_id' => $res['id']));
                    }
                    $result['status'] = 42;
                    $result['message'] = "Connected with success";
                    $result['token'] = $token;
                    $result['level'] = (int)$res['level'];
                    if ($_POST['launcher'] == "0")
                    {
                        $_SESSION['token'] = $token;
                        $_SESSION['level'] = $res['level'];
                        $_SESSION['picture'] = $res['picture'];
                        $_SESSION['username'] = $res['username'];
                        $_SESSION['email'] = $res['email'];
                    }
                }
                else
                {
                    $result['status'] = 43;
                    $result['message'] = "You are banned";
                }
            }
            else
            {
                $result['status'] = 202;
                $result['message'] = "Password or login incorrect";
            }
        }
        else
        {
            $result['status'] = 44;
            $result['message'] = "Account doesn't not exits";
        }
    }
}
else
{
    $result["status"] = 404;
    $result["message"] = "Arguments missing.";
}
echo json_encode($result);