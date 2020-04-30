<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/09/2016
 * Time: 15:24
 */

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['token']) && isset($_POST['id']) && isset($_POST['db_host']) && isset($_POST['db_name']) && isset($_POST['db_user']) && isset($_POST['db_pass']))
{
    $token = $_POST['token'];
    $id = $_POST['id'];

    $encrypter = new Encryption($encrypt_key1, $encrypt_key2);

    $db_host = $encrypter->encrypt_decrypt('encrypt', $_POST['db_host']);
    $db_name = $encrypter->encrypt_decrypt('encrypt', $_POST['db_name']);
    $db_user = $encrypter->encrypt_decrypt('encrypt', $_POST['db_user']);
    $db_pass = $encrypter->encrypt_decrypt('encrypt', $_POST['db_pass']);

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

            $getServer = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
            $getServer->execute(array('id' => $id));
            if ($getServer->rowCount() != 0)
            {
                $getSettings = $database->prepare('UPDATE `servers` SET `db_host`= :db_host, `db_name`= :db_name, `db_user`= :db_user, `db_pass`= :db_pass WHERE id= :id');
                $getSettings->execute(array('id' => $id, 'db_host' => $db_host, 'db_name' => $db_name, 'db_user' => $db_user, 'db_pass' => $db_pass));
                $result['status'] = 42;
                $result['message'] = "Server saved";
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