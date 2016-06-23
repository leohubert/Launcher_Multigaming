<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 17/06/16
 * Time: 17:19
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if ($getSettings = $database->prepare('SELECT * FROM `news` ORDER BY `news`.`date` ASC LIMIT 3'))
{
    $getSettings->execute();
    $result['status'] = 42;
    $result['message'] = "News showed";
    $result['total'] = $getSettings->rowCount();
    $result['news'] = array();
    $i = 0;
    while ($res = $getSettings->fetch())
    {
        $date = date_parse($res['date']);
        $result['news'][$i]['title'] = $res['title'];
        $result['news'][$i]['date'] = $date['day'] . "/" . $date['month'] . "/" . $date['year'];
        $result['news'][$i]['link'] = $res['link'];
        $i++;
    }
}

echo json_encode($result);