<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['support_id']) && isset($_POST['message']))
{
    $token = $_POST['token'];
    $support_id = $_POST['support_id'];
    $message = $_POST['message'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`, `username` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $myUserName = $res['username'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0  && (int)$res['banned'] != 1)
        {
            $getSettings = $database->prepare('SELECT * FROM `support` WHERE id=:id');
            $getSettings->execute(array('id' => $support_id));
            $support = $getSettings->fetch();
            if ($getSettings->rowCount() != 0)
            {
                if ($support['started_by'] == $myID)
                {
                    $checkUser = $database->prepare('INSERT INTO `support_conversation`(`support_id`, `send_by`, `send_at`, `message`) VALUES (:support_id,:send_by,:send_at,:message)');
                    $checkUser->execute(array('support_id' => $support_id, 'send_by' => $myID, 'send_at' => date('Y-m-d H:i:s'), 'message' => $message));
                    $updateSupport = $database->prepare('UPDATE `support` SET `updated_at`=:date WHERE id=:id');
                    $updateSupport->execute(array('id' => $support_id, 'date' => date('Y-m-d H:i:s')));


                    $updateSupport = $database->prepare('SELECT * FROM `support` WHERE id=:id');
                    $updateSupport->execute(array('id' => $support_id));
                    $res = $updateSupport->fetch();

                    if ((int)$res['assign_to'] != 0)
                    {
                        $updateSupport = $database->prepare('INSERT INTO `notifications`(`users`, `title`, `content`, `link`) VALUES (:users, :title, :content, :link)');
                        $updateSupport->execute(array('users' => $res['assign_to'],'title' => 'Support', 'content' => 'New message from ' . $myUserName, 'link' =>  "http://" . $_SERVER['HTTP_HOST']. "/support/view/" . $support_id));
                    }

                    $result['status'] = 42;
                    $result['message'] = "Message send";
                }
                else
                {
                    $result['status'] = 44;
                    $result['message'] = "You don't have right to create this request !";
                }
            }
            else
            {
                $result['status'] = 40;
                $result['message'] = "Conversation doesn't exits";
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