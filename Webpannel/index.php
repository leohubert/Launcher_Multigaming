<?php
/**
 * Created by PhpStorm.
 * User: leohu
 * Date: 30/04/2016
 * Time: 19:14
 */
session_start();

if (isset($_SESSION['email']))
    header("location: panel/");
else
    header("location: panel/login.php");
