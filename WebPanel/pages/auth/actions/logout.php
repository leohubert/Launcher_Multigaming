<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 14/06/16
 * Time: 03:02
 */
session_destroy();
setcookie("token", "", time() - 3600);
setcookie("locked", "", time() - 3600);
header("location: /");