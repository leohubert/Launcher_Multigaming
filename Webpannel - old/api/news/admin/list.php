<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 23/06/2016
 * Time: 13:27
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['show']) && is_numeric($_POST['show']))
{
    $token = $_POST['token'];
    $show = $_POST['show'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 6 && (int)$res['banned'] != 1)
        {
            if ($getSettings = $database->prepare('SELECT * FROM `news` ORDER BY `news`.`date` DESC LIMIT '. $show .''))
            {
                $getSettings->execute();
                $result['status'] = 42;
                $result['message'] = "Result successfully showed";
                $result['total'] = $getSettings->rowCount();
                $result['news'] = array();
                $i = 0;
                while ($res = $getSettings->fetch())
                {
                    $date = date_parse($res['date']);
                    $result['news'][$i]['title'] = $res['title'];
                    $result['news'][$i]['date'] = $date['day'] . "/" . $date['month'] . "/" . $date['year'];
                    $result['news'][$i]['link'] = $res['link'];
                    $result['news'][$i]['id'] = $res['id'];
                    $result['news'][$i]['server_id'] = $res['server_id'];
                    $i++;
                }
            }
        }
        else
        {
            $result['status'] = 44;
            $result['message'] = "You don't have right to create this request !";
        }
    }
    else
    {
        $result['status'] = 41;
        $result['message'] = "Token invalid";
    }
}
else
{
    $result['status'] = 404;
    $result['message'] = "Arguments missing.";
}

echo json_encode($result);