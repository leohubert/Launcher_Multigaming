<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 21:24
 */
header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['db_host']) && isset($_POST['db_name']) && isset($_POST['db_user']) && isset($_POST['db_pass'])
    && isset($_POST['user_name']) && isset($_POST['user_email']) && isset($_POST['user_password'])
    && isset($_POST['user_confpassword']) && isset($_POST['token1']) && isset($_POST['token2'])
    && $_POST['user_name'] != "" && $_POST['user_email'] != "" && $_POST['user_password'] != ""
    && $_POST['user_confpassword'] != "" && $_POST['db_host'] != "" && $_POST['db_name'] != "" && $_POST['db_user'] != "")
{
    if ($_POST['user_password'] == $_POST['user_confpassword'])
    {
        try {
            $database = new PDO('mysql:host='. $_POST['db_host'] .';dbname='. $_POST['db_name'], $_POST['db_user'], $_POST['db_pass']);
            $encrypt = new Encryption($_POST['token1'], $_POST['token2']);
            $password_encrypted = $encrypt->encrypt_decrypt('encrypt', $_POST['user_password']);
            $ip = $_SERVER['REMOTE_ADDR'];
            if (!filter_var($ip, FILTER_VALIDATE_IP)) {
                $ip = "0.0.0.0";
            }
            $uid = "Not found";
            $createAdmin = $database->prepare("INSERT INTO `users`(`email`, `username`, `password`, `level`, `last_ip`, `registered`, `uid`) VALUES (:email,:username,:password,10,:ip,:registered,:uid)");
            $createAdmin->execute(array('email' => $_POST['user_email'], 'username' => $_POST['user_name'], 'password' => $password_encrypted, 'ip' => $ip, 'registered' => date('Y-m-d H:i:s'), 'uid' => $uid));
            $result['status'] = 42;
            $result['message'] = "Admin user created with success";
        } catch (PDOException $e) {
            $result['status'] = 01;
            $result['message'] = $e->getMessage();
        }
    }
    else
    {
        $result["status"] = 44;
        $result["message"] = "The password does not match";
    }

}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);
