<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 12/07/2016
 * Time: 21:00
 */

if (isset($_GET['text']))
{
    echo $encrypter->encrypt_decrypt('encrypt', $_GET['text']);
}
else
    echo  "No text";