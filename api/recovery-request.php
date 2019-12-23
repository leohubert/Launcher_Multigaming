<?php
/**
 * Created by Visual-Code.
 * User: FlashModz
 * Date: 22/12/19
 * Time: 20:34
 */

header('Content-type: application/json');
$result = array("status" => 500, "message" => "Internal error");

$ip = $utility->checkIp();
if (isset($_POST['email'])) {
    $umail = $_POST['email'];
    $recover = json_decode($user->recoveryPassword($umail));

    if ($recover->status == 200) {
        $result["status"] = 200;
        $result["message"] = 'DONE';
        echo json_encode($result);
    }else{
        $result["status"] = 404;
        $result["message"] = $recover->message;
        echo json_encode($result);
    }
}else{
    $result["status"] = 500;
    $result["message"] = 'WTFFF';
    echo json_encode($result);
}