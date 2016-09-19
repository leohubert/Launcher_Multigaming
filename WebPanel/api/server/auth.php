<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 23/07/2016
 * Time: 14:00
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['id']) && isset($_POST['password']))
{
    $id = $_POST['id'];
    $password = $_POST['password'];

    if ($getSettings = $database->prepare('SELECT * FROM `servers` WHERE id = :id'))
    {
        $getSettings->execute(array('id' => $id));
        $res = $getSettings->fetch();
        if ($res['lock'] == $password)
        {
            $result['status'] = 42;
            $result['message'] = "Access success.";
            $result['password'] = $res['lock'];
        }
        else
        {
            $result['status'] = 24;
            $result['message'] = "Access granted.";
        }

    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);