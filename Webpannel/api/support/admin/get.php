<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && is_numeric($_POST['id']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 6  && (int)$res['banned'] != 1)
        {
            $getSettings = $database->prepare('SELECT * FROM `support` WHERE id=:id');
            $getSettings->execute(array('id' => $id));
            $support = $getSettings->fetch();
            if ($getSettings->rowCount() != 0) {
                if ($getSettings = $database->prepare('SELECT * FROM `support_conversation` WHERE support_id=:id ORDER BY `support_conversation`.`send_at` ASC')) {
                    $getSettings->execute(array('id' => $id));
                    $result['status'] = 42;
                    $result['message'] = "Result successfully showed";
                    $result['total'] = $getSettings->rowCount();
                    $result['support_title'] = $support['title'];
                    $result['support_status'] = $support['status'];
                    $result['messages'] = array();
                    $i = 0;
                    while ($conversation = $getSettings->fetch()) {
                        $sender = $database->prepare('SELECT `username`,`picture` FROM users WHERE id = :id');
                        $sender->execute(array('id' => $conversation['send_by']));
                        $sender = $sender->fetch();
                        if ($conversation['send_by'] == $myID)
                            $result['messages'][$i]['me'] = 1;
                        else
                            $result['messages'][$i]['me'] = 0;
                        $result['messages'][$i]['sender_name'] = $sender['username'];
                        $result['messages'][$i]['sender_picture'] = $sender['picture'];
                        $result['messages'][$i]['send_at'] = $conversation['send_at'];
                        $result['messages'][$i]['message'] = $conversation['message'];
                        $i++;
                    }
                }
            }
            else
            {
                $result['status'] = 40;
                $result['message'] = "Conversation do not exist.";
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