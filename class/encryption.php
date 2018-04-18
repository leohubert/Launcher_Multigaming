<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 16:16
 */


class Encryption {

    private static $key_1;
    private static $key_2;

    public function __construct($key_1, $key_2)
    {
        self::$key_1 = $key_1;
        self::$key_2 = $key_2;
    }

    public  function decode($data){

        $first_key = base64_decode(self::$key_1);
        $second_key = base64_decode(self::$key_2);
        $mix = base64_decode($data);

        $method = "aes-256-cbc";
        $iv_length = openssl_cipher_iv_length($method);

        $iv = substr($mix,0,$iv_length);
        $second_encrypted = substr($mix,$iv_length,64);
        $first_encrypted = substr($mix,$iv_length+64);

        $data = openssl_decrypt($first_encrypted,$method,$first_key,OPENSSL_RAW_DATA,$iv);
        $second_encrypted_new = hash_hmac('sha3-512', $first_encrypted, $second_key, TRUE);

        if (hash_equals($second_encrypted,$second_encrypted_new))
            return $data;

        return false;
    }

    public function encode($data){
        $first_key = base64_decode(self::$key_1);
        $second_key = base64_decode(self::$key_2);

        $method = "aes-256-cbc";
        $iv_length = openssl_cipher_iv_length($method);
        $iv = openssl_random_pseudo_bytes($iv_length);

        $first_encrypted = openssl_encrypt($data,$method,$first_key, OPENSSL_RAW_DATA ,$iv);
        $second_encrypted = hash_hmac('sha3-512', $first_encrypted, $second_key, TRUE);

        $output = base64_encode($iv.$second_encrypted.$first_encrypted);
        return $output;
    }
}