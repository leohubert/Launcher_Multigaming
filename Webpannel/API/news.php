<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 01/05/2016
 * Time: 20:38
 */

include "mysql.php";

$requete = $db_trak->prepare('SELECT * FROM news WHERE 1 LIMIT 3');
$requete->execute();

$arr = array();
$i = 0;

while ($reponse = $requete->fetch())
{
    $arr['news'.$i] = array();
    $arr['news'.$i]['title'] = $reponse['title'];
    $arr['news'.$i]['message'] = $reponse['message'];
    $arr['news'.$i]['link'] = $reponse['link'];
    $i++;
}
$arr['total'] = $i;

echo json_encode($arr);