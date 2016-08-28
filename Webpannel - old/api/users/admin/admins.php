<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $my = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$my['level'] >= 6 && (int)$my['banned'] != 1)
        {
            if ($getSettings = $database->prepare('SELECT * FROM `users` WHERE `level` >= 6 ORDER BY `users`.`id` DESC'))
            {
                $getSettings->execute();
                $result['status'] = 42;
                $result['message'] = "Result successfully showed";
                $result['total'] = $getSettings->rowCount();
                $result['users'] = array();
                $i = 0;
                while ($res = $getSettings->fetch())
                {
                    $result['users'][$i]['id'] = $res['id'];
                    $result['users'][$i]['username'] = $res['username'];
                    $result['users'][$i]['email'] = $res['email'];
                    $result['users'][$i]['banned'] = $res['banned'];
                    $result['users'][$i]['level'] = $res['level'];
                    $result['users'][$i]['uid'] = $res['uid'];
                    if ((int)$my['level'] >= 8)
                        $result['users'][$i]['last_ip'] = $res['last_ip'];
                    else
                        $result['users'][$i]['last_ip'] = "Hided";
                    $result['users'][$i]['picture'] = $res['picture'];
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
