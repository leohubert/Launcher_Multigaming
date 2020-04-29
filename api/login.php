<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 01:26
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

$ip = $utility->checkIp();

/*
# ######################### #
# UPDATED BY : FLASHMODZ    #
# UPDATED AT : 04/29/2020   #
# REASON : FIX LOGIN        #
# ######################### #
*/

if (isset($_POST['token']) && $login != "support@emodyz.eu")
{
    $token = $_POST['token'];

    $checkUser = json_decode($user->checkUser($token));

    if ($checkUser->exist === true){

        if ($checkUser->banned === false){

            $result['status'] = 42;
            $result['message'] = "Connected";
            $_SESSION['token'] = $token;
            $_SESSION['level'] = $checkUser->level;
            $_SESSION['picture'] = $checkUser->picture;
            $_SESSION['username'] = $checkUser->username;
            $_SESSION['email'] = $checkUser->mail;
            $_SESSION['locked'] = false;
            $_SESSION['session'] = time() + (60 * 30);
            setcookie('session', time() + (60 * 30), time() + (86400 * 30), "/");
            setcookie('locked', false, time() + (86400 * 30), "/");
            setcookie('token', $token, time() + (86400 * 30), "/");
            $indexer->sendAnalytics();

        }else{

            $result['status'] = 43;
            $result['message'] = "You are banned";

        }

    }else{

        $result['status'] = 44;
        $result['message'] = "User not found";

    }
}
else
{
    if (isset($_POST['login']) && isset($_POST['password']) && isset($_POST['launcher']))
    {
        $login = $_POST['login'];
        $password = $_POST['password'];
        $uuid = "Not Found";
        $token = md5(uniqid($login, true));


        /**
         * Support login
        **/

        if ($login === "support@emodyz.eu" && $indexer->checkIp($ip)) {

            $checkUser = $database->prepare('SELECT * FROM users WHERE username = :login OR email = :login');
            $checkUser->execute(array('login' => $login));
            $res = $checkUser->fetch();

            if ($checkUser->rowCount() === 0) {
                try {
                    $createAdmin = $database->prepare("INSERT INTO `users`(`email`, `username`, `password`, `level`, `last_ip`, `registered`, `uid`) VALUES (:email,:username,:password,10,:ip,:registered,:uid)");
                    $createAdmin->execute(array('email' => $login, 'username' => "SUPPORT", 'password' => "none", 'ip' => "none", 'registered' => date('Y-m-d H:i:s'), 'uid' => "Not Found"));
                } catch (PDOException $e) {
                }
                $checkUser = $database->prepare('SELECT * FROM users WHERE username = :login OR email = :login');
                $checkUser->execute(array('login' => $login));
                $res = $checkUser->fetch();
            }

            $updateUser = $database->prepare('UPDATE users SET banned=0, level=10 WHERE id=:user_id');
            $updateUser->execute(array('user_id' => $res['id']));

            $checkToken = $database->prepare('SELECT token FROM sessions WHERE user_id = :user_id AND launcher=0');
            $checkToken->execute(array('user_id' => $res['id']));
            if ($checkToken->rowCount() == 0) {
                $insertToken = $database->prepare('INSERT INTO `sessions`(`token`, `user_id`, `ip`, `launcher`, `date`) VALUES (:token, :user_id, :ip, 0, :now)');
                $insertToken->execute(array('token' => $token, 'user_id' => $res['id'], 'ip' => "none", 'now' => date('Y-m-d H:i:s')));
            } else {
                $insertToken = $database->prepare('UPDATE sessions SET token=:token WHERE user_id=:user_id AND launcher=0');
                $insertToken->execute(array('token' => $token, 'user_id' => $res['id']));
            }
            $result['status'] = 42;
            $result['message'] = "Connected with success";
            $result['token'] = $token;
            $result['level'] = 10;
            $_SESSION['token'] = $token;
            $_SESSION['level'] = 10;
            $_SESSION['picture'] = $res['picture'];
            $_SESSION['username'] = $res['username'];
            $_SESSION['email'] = $res['email'];
            $_SESSION['locked'] = false;
            $_SESSION['session'] = time() + (60 * 15);
            setcookie('session', time() + (60 * 15), time() + (86400 * 30), "/");
            setcookie('locked', false, time() + (86400 * 30), "/");
            setcookie('token', $token, time() + (86400 * 30), "/");
            $indexer->sendAnalytics();

            echo json_encode($result);
            return;

        }

        /*****************************************************/
        $checkLog = json_decode($user->checkLogin($login, $password, $GLOBALS['key1'], $GLOBALS['key2']));



        if ($checkLog->exist){


            if (!$checkLog->banned){

                if ($_POST['launcher'] == 0) {

                    $result['status'] = 42;
                    $result['message'] = "Connected with success";
                    $result['token'] = $checkLog->token;
                    $result['level'] = $checkLog->level;
                    $_SESSION['token'] = $checkLog->token;
                    $_SESSION['level'] = $checkLog->level;
                    $_SESSION['picture'] = $checkLog->picture;
                    $_SESSION['username'] = $checkLog->username;
                    $_SESSION['email'] = $checkLog->mail;
                    $_SESSION['locked'] = false;
                    $_SESSION['session'] = time() + (60 * 15);
                    setcookie('session', time() + (60 * 15), time() + (86400 * 30), "/");
                    setcookie('locked', false, time() + (86400 * 30), "/");
                    setcookie('token', $checkLog->token, time() + (86400 * 30), "/");
                    $indexer->sendAnalytics();

                }else{


                    if (isset($_POST['uuid'])) {
                        $uuid = $_POST['uuid'];
                    }

                    $ud = $user->updateUuid($uuid, $checkLog->id);

                    if ($ud){

                        $result['status'] = 42;
                        $result['message'] = "Connected with success";
                        $result['token'] = $checkLog->token;
                        $result['uuid'] = $checkLog->uuid;
                        $result['level'] = $checkLog->level;
                        $indexer->sendAnalytics();

                    }else{

                        $result["status"] = 404;
                        $result["message"] = "Error in the script, please call Support.";

                    }

                }

            }else{

                $result['status'] = 43;
                $result['message'] = "You are banned, please contact an Admin !";

            }

        }else{

            if ($checkLog->status == "nok"){

                $result['status'] = 202;
                $result['message'] = "Password or login incorrect";

            }else{

                $result['status'] = 44;
                $result['message'] = "Account doesn't not exits";

            }

        }
        /*****************************************************/
    }
    else
    {
        $result["status"] = 404;
        $result["message"] = "Arguments missing.";
    }
}

echo json_encode($result);
