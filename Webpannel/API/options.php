<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 10/04/2016
 * Time: 00:45
 */

include "mysql.php";

$email = $_POST['email'];
$password = $_POST['password'];

$requete = $db_trak->prepare('SELECT * FROM options WHERE id = 1');
$requete->execute();
$reponse = $requete->fetch();

$arr = array();
$arr['news'] = $reponse['news'];
$arr['news_msg'] = $reponse['news_msg'];
$arr['maintenance'] = $reponse['maintenance'];
$arr['maintenance_image'] = $reponse['maintenance_image'];
$arr['maintenance_msg'] = $reponse['maintenance_msg'];
$arr['login'] = $reponse['login'];
$arr['register'] = $reponse['register'];

echo json_encode($arr);