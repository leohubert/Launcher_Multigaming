<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 29/06/2016
 * Time: 22:30
 */

setcookie('locked', 'true', time() + (86400 * 30), "/");
$_SESSION['locked'] = 'true';
header("location: /");