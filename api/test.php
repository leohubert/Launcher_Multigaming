<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 12/07/2016
 * Time: 21:00
 */





$encrypter = new Encryption($encrypt_key1, $encrypt_key2);

$test1 = "jcehjgfuegjgfkjgjegkulde";
$test2 = "efgh";

$test1encrypted = $encrypter->encrypt_decrypt('encrypt', $test1);
$test2encrypted = $encrypter->encrypt_decrypt('encrypt', $test2);

echo "START<br>";


if ($encrypter->encrypt_decrypt('decrypt', $test1encrypted) == $test1) {
    echo "TRUE 1 <br>";
}


if ($encrypter->encrypt_decrypt('decrypt', $test2encrypted) == $test2) {
    echo "TRUE 2 <br>";
} else {
    var_dump($encrypter->encrypt_decrypt('decrypt', $test2encrypted));
    echo "<br>";
    var_dump($test2);
}

echo $test1encrypted . "<br>" ;
echo $test2encrypted . "<br>";


echo "END<br>";


