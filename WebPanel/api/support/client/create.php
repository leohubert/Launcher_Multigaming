<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 15:20
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['title']) && isset($_POST['message']))
{
    $token = $_POST['token'];
    $title = $_POST['title'];
    $message = $_POST['message'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned`,`username` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $myUserName = $res['username'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0  && (int)$res['banned'] != 1)
        {
            $started_at = date('Y-m-d H:i:s');
            $createSupport = $database->prepare('INSERT INTO `support`(`title`, `started_by`, `started_at`) VALUES (:title,:id,:started_at)');
            $createSupport->execute(array('title' => $title, 'id' => $myID, 'started_at' => $started_at));
            $getSupport = $database->prepare('SELECT * FROM support WHERE started_at = :started_at AND started_by=:id');
            $getSupport->execute(array('started_at' => $started_at, 'id' => $myID));
            $support = $getSupport->fetch();
            $checkUser = $database->prepare('INSERT INTO `support_conversation`(`support_id`, `send_by`, `send_at`, `message`) VALUES (:support_id,:send_by,:send_at,:message)');
            $checkUser->execute(array('support_id' => $support['id'], 'send_by' => $myID, 'send_at' => $started_at, 'message' => $message));
            $updateSupport = $database->prepare('INSERT INTO `notifications`(`users`, `title`, `content`, `link`) VALUES (:users, :title, :content, :link)');
            $updateSupport->execute(array('users' => "-42",'title' => 'Support request', 'content' => 'New support request from ' . $myUserName, 'link' =>  "http://" . $_SERVER['HTTP_HOST']. "/support/view/" . $support['id']));

            $result['status'] = 42;
            $result['message'] = "Support request send";
            $result['support_id'] = $support['id'];
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