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

    function encrypt_decrypt($action, $string) {
        $output = false;
        $encrypt_method = "AES-256-CBC";
        $secret_key = self::$key_1;
        $secret_iv = self::$key_2;
        // hash
        $key = hash('sha256', $secret_key);

        // iv - encrypt method AES-256-CBC expects 16 bytes - else you will get a warning
        $iv = substr(hash('sha256', $secret_iv), 0, 16);
        if ( $action == 'encrypt' ) {
            $output = openssl_encrypt($string, $encrypt_method, $key, 0, $iv);
            $output = base64_encode($output);
        } else if( $action == 'decrypt' ) {
            $output = openssl_decrypt(base64_decode($string), $encrypt_method, $key, 0, $iv);
        }
        return $output;
    }

    public  function decode($data){
        return $this->encrypt_decrypt('decrypt', $data);
    }

    public function encode($data){
        return $this->encrypt_decrypt('encrypt', $data);
    }
}