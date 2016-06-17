<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 17/06/2016
 * Time: 18:24
 */

if (file_exists("arma3/launcher/launcher.exe")){
    header('Content-Description: File Transfer');
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="'.basename('arma3/launcher/launcher.exe').'"');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize('arma3/launcher/launcher.exe'));
    readfile('arma3/launcher/launcher.exe');
    exit;
}
else
{
    echo "Launcher not found";
}