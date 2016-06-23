<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 23/06/2016
 * Time: 13:27
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['title']) && isset($_POST['link'])
    && $_POST['title'] != "" && $_POST['link'] != "")
{
    $token = $_POST['token'];
    $title = $_POST['title'];
    $link = $_POST['link'];

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
            $started_at = date('Y-m-d H:i:s');
            $createNews = $database->prepare('INSERT INTO `news`(`title`, `date`, `link`) VALUES (:title,:started_at,:link)');
            $createNews->execute(array('title' => $title, 'started_at' => $started_at, 'link' => $link));
            $getNews = $database->prepare('SELECT `id` FROM news WHERE started_at = :started_at');
            $getNews->execute(array('started_at' => $started_at));
            $news = $getNews->fetch();
            $result['status'] = 42;
            $result['message'] = "News created";
            $result['support_id'] = $news['id'];
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