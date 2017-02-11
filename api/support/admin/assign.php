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
            $getSettings = $database->prepare('SELECT id, assign_to, status FROM `support` WHERE id=:id');
            $getSettings->execute(array('id' => $id));
            $support = $getSettings->fetch();
            if ($getSettings->rowCount() != 0) {
                if ($support['assign_to'] != $myID)
                {
                    if ($support['status'] == "0")
                    {
                        if ($getSettings = $database->prepare('UPDATE `support` SET `status`=1,`assign_to`=:myid WHERE id=:id')) {
                            $getSettings->execute(array('myid' => $myID, 'id' => $id));
                            $result['status'] = 42;
                            $result['message'] = "Successfully assigned";
                        }
                    }
                    else
                    {
                        if ($getSettings = $database->prepare('UPDATE `support` SET `assign_to`=:myid WHERE id=:id')) {
                            $getSettings->execute(array('myid' => $myID, 'id' => $id));
                            $result['status'] = 42;
                            $result['message'] = "Successfully assigned";
                        }
                    }
                }
                else
                {
                    $result['status'] = 01;
                    $result['message'] = "Already assigned to your account";
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