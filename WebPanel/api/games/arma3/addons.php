<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 17/06/16
 * Time: 17:19
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['id']))
{
    $id = $_POST['id'];

    $getSettings = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
    $getSettings->execute(array('id' => $id));
    if ($getSettings->rowCount()) {
        $res = $getSettings->fetch();
        
        $userconfigs_directory = $res['local_path'];

        if (!$fp = fopen($userconfigs_directory . '/'. $id .'.json', 'r'))
        {
            $result['status'] = 505;
            $result['message'] = "Can't open " .  $userconfigs_directory . '/'. $id .'.json';
        }
        if (!$file = fread($fp, filesize($userconfigs_directory . '/'. $id .'.json')))
        {
            $result['status'] = 504;
            $result['message'] = "Can't read " .  $userconfigs_directory . '/'. $id .'.json';
        }
        else
            $result = json_decode($file);

        fclose($fp);

    }
    else
    {
        $result["status"] = 44;
        $result["message"] = "Server not found";
    }
}
else
{
    $result["status"] = 404;
    $result["message"] = "Arguments missing.";
}


echo json_encode($result);