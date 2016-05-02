<?php
/**
 * Created by PhpStorm.
 * User: wirk
 * Date: 01/05/16
 * Time: 19:58
 */

include "mysql.php";

if (isset($_POST['username']) && isset($_POST['password']) && isset($_POST['password_conf']) && isset($_POST['email']))
{
    $username       =   $_POST['username'];
    $password       =   $_POST['password'];
    $password_conf  =   $_POST['password_conf'];
    $email          =   $_POST['email'];

    $db_trak->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_OBJ);

    if($password != $password_conf)
    {
        $arr = array('status' => 901, 'msg' => "Les mot de passes ne corresponde pas");

    }
    elseif(!filter_var($email, FILTER_VALIDATE_EMAIL))
    {
        $arr = array('status' => 902, 'msg' => "Format de l'email non valide");
    }
    else
    {

        $req = $db_trak->prepare("SELECT username, email FROM users WHERE username = ? OR email = ?");
        $req->execute([$username, $email]);
        $user = $req->fetch();
        if($user){
            $arr = array('status' => 903, 'msg' => "Cette Utilisateur ou E-mail existe deja");
        } else {
            $token = troll_token();
            $req2 = $db_trak->prepare("INSERT INTO users SET username = ?, password = ?, email = ?, level = 0, ip = 0, remember_token = ?");
            $password = password_hash($password, PASSWORD_DEFAULT, ['cost' => 12]);
            $req2->execute([$username, $password, $email, $token]);

            $arr = array('status' => 42, 'msg' => "Registered !", 'email' => $email, 'username' => $username, 'token' => $token);
        }
    }
}
else
{
    $arr = array('status' => 900, 'msg' => "Mot de passe ou identifiant manquant !");
}
echo json_encode($arr);
