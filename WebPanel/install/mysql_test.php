<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 18/06/2016
 * Time: 06:24
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['db_host']) && isset($_POST['db_name']) && isset($_POST['db_user']) && isset($_POST['db_pass'])
    && $_POST['db_host'] != "" && $_POST['db_name'] != "" && $_POST['db_user'] != "")
{
    try {
        $database = new PDO('mysql:host='. $_POST['db_host'] .';dbname='. $_POST['db_name'], $_POST['db_user'], $_POST['db_pass']);
        $result['status'] = 42;
        $result['message'] = "Db successfully connected";
    } catch (PDOException $e) {
        $result['status'] = 01;
        $result['message'] = $e->getMessage();
    }
}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);
