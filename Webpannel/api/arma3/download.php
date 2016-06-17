<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 17/06/2016
 * Time: 18:24
 */

if (isset($match['params']['addons']))
{
    if (file_exists("arma3/modpack/addons/".$match['params']['addons']."")){
        header('Content-Description: File Transfer');
        header('Content-Type: application/octet-stream');
        header('Content-Disposition: attachment; filename="'.basename('arma3/modpack/addons/'.$match['params']['addons'].'').'"');
        header('Expires: 0');
        header('Cache-Control: must-revalidate');
        header('Pragma: public');
        header('Content-Length: ' . filesize('arma3/modpack/addons/'.$match['params']['addons'].''));
        readfile('arma3/modpack/addons/'.$match['params']['addons'].'');
        exit;
    }
    else{
        echo "File not found: ".$match['params']['addons']."";
    }
}
else if (isset($match['params']['cpps']))
{
    if (file_exists("arma3/modpack/".$match['params']['cpps']."")){
        header('Content-Description: File Transfer');
        header('Content-Type: application/octet-stream');
        header('Content-Disposition: attachment; filename="'.basename('arma3/modpack/'.$match['params']['cpps'].'').'"');
        header('Expires: 0');
        header('Cache-Control: must-revalidate');
        header('Pragma: public');
        header('Content-Length: ' . filesize('arma3/modpack/'.$match['params']['cpps'].''));
        readfile('arma3/modpack/'.$match['params']['cpps'].'');
        exit;
    }
    else{
        echo "File not found: ".$match['params']['addons']."";
    }
}
else if (isset($match['params']['userconfigs']))
{
    if (file_exists("arma3/".$match['params']['userconfigs']."")){
        header('Content-Description: File Transfer');
        header('Content-Type: application/octet-stream');
        header('Content-Disposition: attachment; filename="'.basename('arma3/'.$match['params']['userconfigs'].'').'"');
        header('Expires: 0');
        header('Cache-Control: must-revalidate');
        header('Pragma: public');
        header('Content-Length: ' . filesize('arma3/'.$match['params']['userconfigs'].''));
        readfile('arma3/'.$match['params']['userconfigs'].'');
        exit;
    }
    else{
        echo "File not found: ".$match['params']['addons']."";
    }
}