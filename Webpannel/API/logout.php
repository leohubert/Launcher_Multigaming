<?php
/**
 * Created by PhpStorm.
 * User: leandr_g
 * Date: 18/04/2016
 * Time: 21:37
 */

include "mysql.php";

if (isset($_POST['token']))
{
    $token = $_POST['token'];
    $requete = $db_trak->prepare('DELETE FROM session WHERE `token` = :token');
    $requete->bindParam(':token', $token, PDO::PARAM_STR);
    $requete->execute();
    if ($requete->rowCount() != 0)
        $arr = array('status' => 41, 'msg' => "Deconnecte avec succes !");
    else
        $arr = array('status' => 202, 'msg' => "Session non existante !");
}
else
    $arr = array('status' => 404, 'msg' => "Token manquant !");
echo json_encode($arr);