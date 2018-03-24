<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 01:26
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

$ip = $_SERVER['REMOTE_ADDR'];
if (!filter_var($ip, FILTER_VALIDATE_IP)) {
    $ip = "0.0.0.0";
}

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0)
    {
        if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT * FROM users WHERE id = :id')) {
            $userLevel->execute(array('id' => $res['user_id']));
            if ($userLevel->rowCount() != 0)
            {
                $res = $userLevel->fetch();
                $checkBanIP = $database->prepare('SELECT id FROM users WHERE banned=1 AND last_ip=:ip');
                $checkBanIP->execute(array('ip' => $res['last_ip']));
                if ($checkBanIP->rowCount() == 0 && (int)$res['banned'] != 1) {
                    $result['status'] = 42;
                    $result['message'] = "Connected";
                    $_SESSION['token'] = $token;
                    $_SESSION['level'] = $res['level'];
                    $_SESSION['picture'] = $res['picture'];
                    $_SESSION['username'] = $res['username'];
                    $_SESSION['email'] = $res['email'];
                    $_SESSION['locked'] = false;
                    $_SESSION['session'] = time() + (60 * 30);
                    setcookie('session', time() + (60 * 30), time() + (86400 * 30), "/");
                    setcookie('locked', false, time() + (86400 * 30), "/");
                    setcookie('token', $token, time() + (86400 * 30), "/");
                }
                else
                {
                    $result['status'] = 43;
                    $result['message'] = "You are banned";
                }
            }
            else
            {
                $result['status'] = 44;
                $result['message'] = "User not found";
            }
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
    if (isset($_POST['login']) && isset($_POST['password']) && isset($_POST['launcher']))
    {
        $login = $_POST['login'];
        $password = $_POST['password'];
        $uuid = "Not Found";

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
                    $checkBanIP = $database->prepare('SELECT id FROM users WHERE banned=1 AND last_ip=:ip');
                    $checkBanIP->execute(array('ip' => $res['last_ip']));
                    if ($checkBanIP->rowCount() == 0 && (int)$res['banned'] != 1) {
                        if ($_POST['launcher'] == 0)
                        {
                            $token = md5(uniqid($login, true));
                            $checkToken = $database->prepare('SELECT token FROM sessions WHERE user_id = :user_id AND launcher=0');
                            $checkToken->execute(array('user_id' => $res['id']));
                            if ($checkToken->rowCount() == 0) {
                                $insertToken = $database->prepare('INSERT INTO `sessions`(`token`, `user_id`, `ip`, `launcher`, `date`) VALUES (:token, :user_id, :ip, 0, :now)');
                                $insertToken->execute(array('token' => $token, 'user_id' => $res['id'], 'ip' => $ip, 'now' => date('Y-m-d H:i:s')));
                            } else {
                                $insertToken = $database->prepare('UPDATE sessions SET token=:token WHERE user_id=:user_id AND launcher=0');
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
                            $_SESSION['token'] = $token;
                            $_SESSION['level'] = $res['level'];
                            $_SESSION['picture'] = $res['picture'];
                            $_SESSION['username'] = $res['username'];
                            $_SESSION['email'] = $res['email'];
                            $_SESSION['locked'] = false;
                            $_SESSION['session'] = time() + (60 * 15);
                            setcookie('session', time() + (60 * 15), time() + (86400 * 30), "/");
                            setcookie('locked', false, time() + (86400 * 30), "/");
                            setcookie('token', $token, time() + (86400 * 30), "/");
                        }
                        else
                        {
                            $token = md5(uniqid($login, true));
                            $checkToken = $database->prepare('SELECT token FROM sessions WHERE user_id = :user_id AND launcher = 1');
                            $checkToken->execute(array('user_id' => $res['id']));
                            if (isset($_POST['uuid'])) {
                              $uuid = $_POST['uuid'];
                            }
                            $updateUuid = $database->prepare('UPDATE users SET uid=:uuid WHERE id=:user_id');
                            $updateUuid->execute(array('uuid' => $uuid, 'user_id' => $res['id']));
                            if ($checkToken->rowCount() == 0) {
                                $insertToken = $database->prepare('INSERT INTO `sessions`(`token`, `user_id`, `ip`, `launcher`, `date`) VALUES (:token, :user_id, :ip, 1, :now)');
                                $insertToken->execute(array('token' => $token, 'user_id' => $res['id'], 'ip' => $ip, 'now' => date('Y-m-d H:i:s')));
                            } else {
                                $insertToken = $database->prepare('UPDATE sessions SET token=:token WHERE user_id=:user_id AND launcher = 1');
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
                            $result['uuid'] = $uuid;
                            $result['level'] = (int)$res['level'];
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
}

echo json_encode($result);
