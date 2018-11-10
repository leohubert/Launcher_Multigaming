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

    $checkrespons = $config->update($paramname, $content, $token);

    if ($checkrespons === true){

        $result['status'] = 42;
        $result['message'] = "Update with Success !";

        echo json_encode($result);
    }

    if ($checkrespons === false){

        $result['status'] = 980;
        $result['message'] = "Update with Success !";

        echo json_encode($result);
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";

    return json_encode($result);
}