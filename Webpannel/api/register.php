<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 01:26
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['email']) && isset($_POST['username']) && isset($_POST['password']) && isset($_POST['confirm_password']) && isset($_POST['launcher'])) {
    $email = $_POST['email'];
    $username = $_POST['username'];
    $password = $_POST['password'];
    $confirm_password = $_POST['confirm_password'];
    $launcher = $_POST['launcher'];

    $getSettings = $database->prepare('SELECT * FROM settings WHERE active = 1');
    $getSettings->execute();
    $res = $getSettings->fetch();
    if ($res['register'] == "1") {
        if (preg_match('/^[A-Za-z][A-Za-z0-9 ]{3,31}$/', $username)) {
            if (preg_match('/^(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5C\x22]\x22?)){255,})(?!(?:(?:\x22?\x5C[\x00-\x7E]\x22?)|(?:\x22?[^\x5C\x22]\x22?)){65,}@)(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22))(?:\.(?:(?:[\x21\x23-\x27\x2A\x2B\x2D\x2F-\x39\x3D\x3F\x5E-\x7E]+)|(?:\x22(?:[\x01-\x08\x0B\x0C\x0E-\x1F\x21\x23-\x5B\x5D-\x7F]|(?:\x5C[\x00-\x7F]))*\x22)))*@(?:(?:(?!.*[^.]{64,})(?:(?:(?:xn--)?[a-z0-9]+(?:-[a-z0-9]+)*\.){1,126}){1,}(?:(?:[a-z][a-z0-9]*)|(?:(?:xn--)[a-z0-9]+))(?:-[a-z0-9]+)*)|(?:\[(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){7})|(?:(?!(?:.*[a-f0-9][:\]]){7,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,5})?)))|(?:(?:IPv6:(?:(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){5}:)|(?:(?!(?:.*[a-f0-9]:){5,})(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3})?::(?:[a-f0-9]{1,4}(?::[a-f0-9]{1,4}){0,3}:)?)))?(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))(?:\.(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:1[0-9]{2})|(?:[1-9]?[0-9]))){3}))\]))$/iD', $email)) {
                if (strlen($password) >= 8) {
                        $getUsers = $database->prepare('SELECT * FROM users WHERE email = :email');
                        $getUsers->execute(array('email' => $email));
                        if ($getUsers->rowCount() == 0) {
                            $getUsers = $database->prepare('SELECT * FROM users WHERE username = :username');
                            $getUsers->execute(array('username' => $username));
                            if ($getUsers->rowCount() == 0) {
                                if ($password == $confirm_password) {
                                    $encrypt = new Encryption($encrypt_key);
                                    $password_encrypted = $encrypt->encode($password);
                                    $ip = $_SERVER['REMOTE_ADDR'];
                                    if (!filter_var($ip, FILTER_VALIDATE_IP)) {
                                        $ip = "0.0.0.0";
                                    }
                                    $register = $database->prepare('INSERT INTO `users`(`email`, `username`, `password`, `last_ip`, `registered`) VALUES (:email,:username,:password,:ip,:registered)');
                                    $register->execute(array('email' => $email, 'username' => $username, 'password' => $password_encrypted, 'ip' => $ip, 'registered' => date('Y-m-d H:i:s')));
                                    $result['status'] = 42;
                                    $result['message'] = "Registered";
                                } else {
                                    $result['status'] = 01;
                                    $result['message'] = "Password doesn't match";
                                }
                            } else {
                                $result['status'] = 01;
                                $result['message'] = "Username already used";
                            }
                        } else {
                            $result['status'] = 01;
                            $result['message'] = "Email already used";
                        }
                } else {
                    $result['status'] = 01;
                    $result['message'] = "8 character min for password";
                }
            } else {
                $result['status'] = 01;
                $result['message'] = "Email not good";
            }
        } else {
            $result['status'] = 01;
            $result['message'] = "Username not good";
        }
    } else {
        $result["status"] = 39;
        $result["message"] = "Register desactived !";
    }
}
else
{
   $result["status"] = 404;
   $result["message"] = "Arguments missing.";
}
echo json_encode($result);
