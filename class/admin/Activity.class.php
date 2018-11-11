<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 10-11-18
 * Time: 20:30
 */

class Activity{

    /* Cookies */

    /* Session */

    /* Admin Tools */

    /**
     * Check Ip for the User has not the server
     * @return array|false|string
     */
    public function checkIp(){

        if (isset($_SERVER)){
            if(isset($_SERVER["HTTP_X_FORWARDED_FOR"])){
                $ip = $_SERVER["HTTP_X_FORWARDED_FOR"];
                if(strpos($ip,",")){
                    $exp_ip = explode(",",$ip);
                    $ip = $exp_ip[0];
                }
            }else if(isset($_SERVER["HTTP_CLIENT_IP"])){
                $ip = $_SERVER["HTTP_CLIENT_IP"];
            }else{
                $ip = $_SERVER["REMOTE_ADDR"];
            }
        }else{
            if(getenv('HTTP_X_FORWARDED_FOR')){
                $ip = getenv('HTTP_X_FORWARDED_FOR');
                if(strpos($ip,",")){
                    $exp_ip=explode(",",$ip);
                    $ip = $exp_ip[0];
                }
            }else if(getenv('HTTP_CLIENT_IP')){
                $ip = getenv('HTTP_CLIENT_IP');
            }else {
                $ip = getenv('REMOTE_ADDR');
            }
        }
        return $ip;

    }

    /* Other */

}