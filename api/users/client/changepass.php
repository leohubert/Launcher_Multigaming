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

    $current_pass = $encrypter->encrypt_decrypt('encrypt', $current_pass);
    $new_pass = $encrypter->encrypt_decrypt('encrypt', $new_pass);
    $confirm_pass = $encrypter->encrypt_decrypt('encrypt', $confirm_pass);

    $resp = json_decode($user->checkUser($token));

    if ($resp->exist === true) {
        $id = $resp->id;
        $userLevel = $resp->level;

        if (strlen($new_pass) >= 8 && strlen($confirm_pass) >= 8) {
            if ($new_pass === $confirm_pass) {
                $p = json_decode($user->changePasswd($resp->id, $current_pass, $new_pass, $confirm_pass));

                if ($resp->banned === false) {
                    if ($p->res === true) {
                        $result['status'] = 42;
                        $result['message'] = "User successfully saved";
                    } else {
                        $result['status'] = 01;
                        $result['message'] = "New password doesn't match !";
                    }
                }else{
                    $result['status'] = 44;
                    $result['message'] = "You don't have right to create this request !";
                }
            }else{
                $result['status'] = 40;
                $result['message'] = "Current password not good !";
            }
        }else{
            $result['status'] = 01;
            $result['message'] = "Minimum 8 character for password !";
        }
    }else{
        $result['status'] = 41;
        $result['message'] = "Account not found";
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);
