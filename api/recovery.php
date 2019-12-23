<?php
/**
 * Created by Visual-Code.
 * User: FlashModz
 * Date: 22/12/19
 * Time: 23:34
 */

header('Content-type: application/json');
$result = array("status" => 500, "message" => "Internal error");

$ip = $utility->checkIp();
if (isset($_POST['code'])) {
    $code = $_POST['code'];
    $ccl = json_decode($user->ckrecoveryPassword($code));
    if ($ccl->status == 200){
        if (isset($_POST['password'])){
            $password = $_POST['password'];
            if ($password == $_POST['retype_password']){
                $retype_password = $_POST['retype_password'];
                $resp = json_decode($user->changePasswdRec($code, $password, $retype_password));
                if ($resp->status == 20){
                    $result["status"] = 20;
                    $result["message"] = 'Your password has been sucessfully changed !';
                    echo json_encode($result);
                }elseif ($resp->status == 30){
                    $result["status"] = 30;
                    $result["message"] = 'Your code has not longer valid !';
                    echo json_encode($result);
                }else{
                    $result["status"] = 50;
                    $result["message"] = 'Server error !';
                    echo json_encode($result); 
                }    
            }else{
                $result["status"] = 40;
                $result["message"] = 'password not Match';
                echo json_encode($result); 
            }
        }else{
            $result["status"] = 40;
            $result["message"] = 'password not valid';
            echo json_encode($result);
        }
    }else{
        $result["status"] = 50;
        $result["message"] = 'Your code has not longer valid !';
        echo json_encode($result); 
    }
    
}else{
    $result["status"] = 500;
    $result["message"] = 'Your IP has been reported';
    echo json_encode($result);
}