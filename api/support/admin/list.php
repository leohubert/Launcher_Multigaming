<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
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
                if ($getSettings = $database->prepare('SELECT * FROM `support` ORDER BY `support`.`started_at` DESC LIMIT '. $show .''))
                {
                    $getSettings->execute();
                    $result['status'] = 42;
                    $result['message'] = "Result successfully showed";
                    $result['total'] = $getSettings->rowCount();
                    $result['support'] = array();
                    $i = 0;
                    while ($res = $getSettings->fetch())
                    {
                        $result['support'][$i]['title'] = $res['title'];
                        $result['support'][$i]['status'] = $res['status'];
                        $user = $database->prepare('SELECT `username` FROM users WHERE id = :id');
                        $user->execute(array('id' => $res['started_by']));
                        $userName = $user->fetch();
                        $result['support'][$i]['started_by'] = $userName['username'];
                        $result['support'][$i]['started_by_id'] = $res['started_by'];
                        $result['support'][$i]['started_at'] = $res['started_at'];
                        $result['support'][$i]['updated_at'] = $res['updated_at'];
                        $user = $database->prepare('SELECT `username` FROM users WHERE id = :id');
                        $user->execute(array('id' => $res['assign_to']));
                        $userName = $user->fetch();
                        $result['support'][$i]['assign_to'] = $userName['username'];
                        $result['support'][$i]['assign_to_id'] = $res['assign_to'];
                        $result['support'][$i]['support_id'] = $res['id'];
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