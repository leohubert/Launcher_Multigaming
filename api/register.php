<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 01:26
 */
header('Content-type: application/json');
$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['email']) && isset($_POST['username']) && isset($_POST['password']) && isset($_POST['confirm_password'])) {
    $email = htmlspecialchars($_POST['email']);
    $username = htmlspecialchars($_POST['username']);
    $password = htmlspecialchars($_POST['password']);
    $confirm_password = htmlspecialchars($_POST['confirm_password']);

    $ip = $utility->checkIp();
    $register = json_decode($user->createUsersT($email,$username,$password,$confirm_password, $ip));
    if ($register->code == "000"){
        $result['status'] = $register->code;
        $result['title'] = $register->title;
        $result['message'] = $register->message;
        $indexer->sendAnalytics();
    }else{
        $result['status'] = 01;
        $result['title'] = $register->title;
        $result['message'] = $register->message;
    }
}else {
    $result["status"] = 404;
    $result["message"] = "Critical error";
}
echo json_encode($result);
