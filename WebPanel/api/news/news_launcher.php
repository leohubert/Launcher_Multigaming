<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 17/06/16
 * Time: 17:19
 */


header('Content-type: application/json');
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Methods: POST');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['id']))
{
    $id = $_POST['id'];

    if ($getSettings = $database->prepare('SELECT * FROM `news` WHERE server_id=:id ORDER BY `news`.`date` DESC LIMIT 3'))
    {
        $getSettings->execute(array('id' => $id));
        $result['status'] = 42;
        $result['message'] = "News showed";
        $result['total'] = $getSettings->rowCount();
        $result['news'] = array();
        $i = 0;
        while ($res = $getSettings->fetch())
        {
            $date = date_parse($res['date']);
            $result['news'][$i]['title'] = $res['title'];
            $result['news'][$i]['content'] = $res['content'];
            $result['news'][$i]['date'] = $date['day'] . "/" . $date['month'] . "/" . $date['year'];
            $result['news'][$i]['link'] = $res['link'];
            $i++;
        }
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}


echo json_encode($result);