<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 16:16
 */


class Encryption {

    private static $key;

    public function __construct($key)
    {
        self::$key = $key;
    }

    public  function encode($data){

        $l = strlen(self::$key);
        if ($l < 16)
            $key = str_repeat(self::$key, ceil(16/$l));

        if ($m = strlen($data)%8)
            $data .= str_repeat("\x00",  8 - $m);
        if (function_exists('mcrypt_encrypt'))
            $val = mcrypt_encrypt(MCRYPT_BLOWFISH, self::$key, $data, MCRYPT_MODE_ECB);
        else
            $val = openssl_encrypt($data, 'BF-ECB', self::$key, OPENSSL_RAW_DATA | OPENSSL_NO_PADDING);

        return $val;
    }

    public function decode($data){
        $l = strlen(self::$key);
        if ($l < 16)
            $key = str_repeat(self::$key, ceil(16/$l));

        if (function_exists('mcrypt_encrypt'))
            $val = mcrypt_decrypt(MCRYPT_BLOWFISH, self::$key, $data, MCRYPT_MODE_ECB);
        else
            $val = openssl_decrypt($data, 'BF-ECB', self::$key, OPENSSL_RAW_DATA | OPENSSL_NO_PADDING);
        return $val;
    }
}