<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 10/04/2016
 * Time: 00:45
 */

include "mysql.php";

if (isset($_POST['login']) && isset($_POST['password']))
{
    $login = $_POST['login'];
    $password = $_POST['password'];

    $requete = $db_trak->prepare('SELECT * FROM users WHERE email = :email OR username = :username');
    $requete->bindParam(':email', $login, PDO::PARAM_STR);
    $requete->bindParam(':username', $login, PDO::PARAM_STR);
    $requete->execute();
    $reponse = $requete->fetch();

    if (password_verify($password, $reponse['password']))
    {
        $arr = array('status' => 42, 'msg' => "Connected !", 'level' => $reponse['level'], 'email' => $reponse['email'], 'username' => $reponse['username']);
    }
    else
    {
        $arr = array('status' => 202, 'msg' => "Mot de passe ou identifiant incorrect !");
    }
}
else
{
    $arr = array('status' => 404, 'msg' => "Mot de passe ou identifiant manquant !");
}
echo json_encode($arr);