<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/08/2016
 * Time: 01:09
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && is_numeric($_POST['remove_folder']) && isset($_POST['remove_folder']) && is_numeric($_POST['remove_folder'])
    && ($_POST['remove_folder'] == 1 || $_POST['remove_folder'] == 0))
{
    $token = $_POST['token'];
    $id = $_POST['id'];
    $remove = (int)$_POST['remove_folder'];

    $checkUser = $database->prepare('SELECT user_id FROM sessions WHERE token = :token');
    $checkUser->execute(array('token' => $token));
    $res = $checkUser->fetch();
    if ($checkUser->rowCount() != 0 && $userLevel = $database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
    {
        $userLevel->execute(array('id' => $res['user_id']));
        $myID = $res['user_id'];
        $res = $userLevel->fetch();
        if ($userLevel->rowCount() != 0 && (int)$res['level'] >= 9  && (int)$res['banned'] != 1)
        {
            $allOk = true;

            $getServer = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
            $getServer->execute(array('id' => $id));
            if ($getServer->rowCount() != 0)
            {
                if ($remove == 1)
                {
                    $getServer = $getServer->fetch();
                    $getServer = $getServer['local_path'];

                    $getServer = trim($getServer);
                    if (is_dir($getServer))
                        exec('rm -rf ' . $getServer);
                    else
                        $allOk == false;
                }

                if ($allOk == true)
                {
                    $getSettings = $database->prepare('DELETE FROM `servers` WHERE id= :id');
                    $getSettings->execute(array('id' => $id));
                    $result['status'] = 42;
                    $result['message'] = "Server deleted";
                }
                else
                {
                    $result['status'] = 18;
                    $result['message'] = "Can't remove directory, verify your local path and permission (777) ";
                }
            }
            else
            {
                $result['status'] = 404;
                $result['message'] = "Server not found";
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