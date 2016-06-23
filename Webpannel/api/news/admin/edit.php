<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 23/06/2016
 * Time: 13:27
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['title']) && isset($_POST['link']) && isset($_POST['id'])
    && $_POST['title'] != "" && $_POST['link'] != "" && is_numeric($_POST['id']))
{
    $token = $_POST['token'];
    $title = $_POST['title'];
    $link = $_POST['link'];
    $id = $_POST['id'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0  && (int)$res['banned'] != 1 && (int)$res['level'] >= 9)
        {
            $editNews = $database->prepare('UPDATE `news` SET `title`= :title, `link`=:link WHERE id=:id');
            $editNews->execute(array('title' => $title,  'link' => $link, 'id' => $id));
            $result['status'] = 42;
            $result['message'] = "News edited";
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