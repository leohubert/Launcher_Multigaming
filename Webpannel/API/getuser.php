<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 10/04/2016
 * Time: 00:45
 */

include "mysql.php";

if (isset($_POST['token']))
{
    $token = $_POST['token'];

    $requete = $db_trak->prepare('SELECT id, username, email, level FROM users WHERE remember_token = :token');
    $requete->bindParam(':token', $token, PDO::PARAM_STR);
    $requete->execute();
    $reponse = $requete->fetch();

    if(empty($reponse)){
        $arr = array('status' => 400, 'msg' => "toekn incorrect");
    } else {
        $arr = array('status' => 42, 'msg' => "Connected With token !", 'level' => $reponse['level'], 'email' => $reponse['email'], 'username' => $reponse['username']);
    }
}
else
{
    $arr = array('status' => 404, 'msg' => "token manquent");
}
echo json_encode($arr);