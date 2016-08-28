<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['current_pass']) && isset($_POST['new_pass']) && isset($_POST['confirm_pass']))
{
    $token = $_POST['token'];
    $current_pass = $_POST['current_pass'];
    $new_pass = $_POST['new_pass'];
    $confirm_pass = $_POST['confirm_pass'];

    $encrypted = new Encryption($encrypt_key);
    $current_pass = $encrypted->encode($current_pass);
    $new_pass = $encrypted->encode($new_pass);
    $confirm_pass = $encrypted->encode($confirm_pass);

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`,`password` FROM users WHERE id = :id'))
    {
        $id = $res['user_id'];
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ($my['password'] == $current_pass)
        {
            if (strlen($new_pass) >= 8 && strlen($confirm_pass) >= 8)
            {
                if ($new_pass == $confirm_pass)
                {
                    if ((int)$my['level'] != 0 && (int)$my['banned'] != 1)
                    {
                        $saveUser = $database->prepare('UPDATE `users` SET `password`=:password WHERE id=:id');
                        $saveUser->execute(array('password' => $confirm_pass, 'id' => $id));
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
                    $result['status'] = 01;
                    $result['message'] = "New password doesn't match !";
                }
            }
            else
            {
                $result['status'] = 01;
                $result['message'] = "Minimum 8 character for password !";
            }

        }
        else
        {
            $result['status'] = 40;
            $result['message'] = "Current password not good !";
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
