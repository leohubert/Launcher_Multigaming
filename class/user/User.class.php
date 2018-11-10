<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 10-11-18
 * Time: 22:26
 */
class User{

    private $database;
    private $token;
    private $ip;
    private $uuid;

    public function __construct($database){
        $this->database = $database;
    }

    public function checkUser($token){

        $this->token = $token;

        $sql = $this->database->prepare('SELECT user_id FROM sessions WHERE token = :token');
        $sql->execute(array('token' => $this->token));
        $res = $sql->fecth();

        if ($sql->rowCount() != 0){

            $sqlcomplete = $this->database->prepare('SELECT * FROM users WHERE id = :id');
            $sqlcomplete->execute(array('id' => $res['user_id']));

            if ($sqlcomplete->rowCount() != 0){

                $rescomplete = $sqlcomplete->fecth();
                $bannedip = $this->checkBanIp($rescomplete['last_ip']);
                $banneduuid = $this->checkBanUuid(['uid']);


                if ($bannedip != false && $banneduuid != false && (int)$rescomplete['banned'] != 1){
                    $result['status'] = 42;
                    $result['message'] = "Connected";
                    $_SESSION['token'] = $this->token;
                    $_SESSION['level'] = $rescomplete['level'];
                    $_SESSION['picture'] = $rescomplete['picture'];
                    $_SESSION['username'] = $rescomplete['username'];
                    $_SESSION['email'] = $rescomplete['email'];
                    $_SESSION['locked'] = false;
                    $_SESSION['session'] = time() + (60 * 30);
                    setcookie('session', time() + (60 * 30), time() + (86400 * 30), "/");
                    setcookie('locked', false, time() + (86400 * 30), "/");
                    setcookie('token', $this->token, time() + (86400 * 30), "/");

                    return 42;
                }

                return 43;

            }

            return 44;
        }

        return 41;

    }

    public function checkLevel($token){
        $this->token = $token;

        $sql = $this->database->prepare('SELECT user_id FROM sessions WHERE token = :token');
        $sql->execute(array('token' => $this->token));
        $res = $sql->fecth();

        if ($sql->rowCount() != 0){

            $sqlcomplete = $this->database->prepare('SELECT * FROM users WHERE id = :id');
            $sqlcomplete->execute(array('id' => $res['user_id']));

            if ($sqlcomplete->rowCount() != 0){

                $rescomplete = $sqlcomplete->fecth();
                $bannedip = $this->checkBanIp($rescomplete['last_ip']);
                $banneduuid = $this->checkBanUuid(['uid']);


                if ($bannedip != false && $banneduuid != false && (int)$rescomplete['banned'] != 1){
                    $level = (int)$rescomplete['level'];
                    return $level;
                }

                return 43;

            }
        }
    }

    private function checkBanIp($ip){

        $this->ip = $ip;

        $sql = $this->database->prepare('SELECT id FROM users WHERE banned=1 AND last_ip=:ip');
        $sql->execute(array('ip' => $this->ip));

        if ($sql->rowCount() == 0){
            return true;
        }else{
            return false;
        }

    }

    private function checkBanUuid($uuid){
        $this->uuid = $uuid;

        $sql = $this->database->prepare('SELECT id FROM users WHERE banned=1 AND uid=:uid');
        $sql->execute(array('uid' => $this->uuid));

        if ($sql->rowCount() == 0){
            return true;
        }else{
            return false;
        }
    }


}