<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 13:14
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['msg_title']) && isset($_POST['msg_content']))
{
    $token = $_POST['token'];
    $content = $_POST['msg_content'];
    $content1 = $_POST['msg_title'];

    $request = $config->update("login", $content, $content1, $token);

    if ($request === true){

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

    echo json_encode($result);
}