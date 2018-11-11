<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 10-11-18
 * Time: 12:01
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['name']) && isset($_POST['send']))
{
    $token = $_POST['token'];
    $paramname = $_POST['name'];
    $content = $_POST['send'];
    if (isset($_POST['send1'])){
        $content1 = $_POST['send1'];
    }else{
        $content1 = "Alright";
    }

    $checkrespons = $config->update($paramname, $content, $content1, $token);

    if ($checkrespons === true){

        $result['status'] = 42;
        $result['message'] = "Update with Success !";

        echo json_encode($result);
    }else{
        $result['status'] = 44;
        $result['message'] = "You are not authorized.";

        echo json_encode($result);
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";

    return json_encode($result);
}