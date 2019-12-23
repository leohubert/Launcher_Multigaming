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
    private $userid;
    private $ip;
    private $usmail;


    public function __construct($database){

        $this->database = $database;
        $this->ip = new Activity();

    }

    public function checkUser($token){

        $this->token = HtmlSpecialChars($token);

        $check = $this->database->prepare('SELECT user_id FROM sessions WHERE token = :token');
        $check->execute(array('token' => $this->token));
        $res = $check->fetch();

        if ($check->rowCount() != 0 && $checklevel = $this->database->prepare('SELECT * FROM users WHERE id = :id')) {

            $checklevel->execute(array('id' => $res['user_id']));
            $this->userid = $res['user_id'];
            $res = $checklevel->fetch();
            $newip = $this->ip->checkIp();

            if ($res['uid'] = "Not Found"){
                $res['uid'] = "Not Set";
            }

            if ($checklevel->rowCount() != 0 && (int)$res['banned'] != 1 && $this->checkBannedIp($res['last_ip'])->rowCount() == 0 && $this->checkBannedUuid($res['uid'])->rowCount() == 0 ) {

                if ($newip != $res['last_ip']){

                    $updateip = $this->database->prepare('UPDATE users SET last_ip=:ip WHERE id=:user_id');
                    $updateip->execute(array('ip' => $newip, 'user_id' => (int)$this->userid));

                }

                $data = array(
                    'exist' => true,
                    'id' => (int)$this->userid,
                    'level' => (int)$res['level'],
                    'banned' => false,
                    'ip' => $newip,
                    'uuid' => $res['uid'],
                    'mail' => $res['email'],
                    'username' => $res['username'],
                    'picture' => $res['picture'],
                    'token' => $this->token,
                );

                return json_encode($data);

            } else {

                $data = array(
                    'exist' => true,
                    'id' => (int)$this->userid,
                    'level' => "",
                    'banned' => true,
                    'ip' => "",
                    'uuid' => "",
                    'mail' => $res['email'],
                    'username' => $res['username'],
                    'picture' => $res['picture'],
                    'token' => $this->token,
                );

                return json_encode($data);
            }

        } else {

            $data = array(
                'exist' => false,
                'id' => 0,
                'level' => 0,
                'banned' => false,
                'ip' => "",
                'uuid' => "",
                'mail' => "",
                'username' => "",
                'picture' => "",
                'token' => "",
            );

            return json_encode($data);

        }

    }

    public function createUser(){

    }

    private function checkBannedIp($ip){

        $checkBanIP = $this->database->prepare('SELECT id FROM users WHERE banned=1 AND last_ip=:ip');
        $checkBanIP->execute(array('ip' => $ip));

        return $checkBanIP;

    }

    private function checkBannedUuid($uuid){

        $checkBanUuid = $this->database->prepare('SELECT id FROM users WHERE banned=1 AND uid=:uid');
        $checkBanUuid->execute(array('uid' => $uuid));

        return $checkBanUuid;

    }

    public function checkLogin($login, $passwd, $key1, $key2){

        $checkLogMeIn = $this->database->prepare('SELECT * FROM users WHERE username = :login OR email = :login');
        $checkLogMeIn->execute(array('login' => $login));

        $res = $checkLogMeIn->fetch();
        $encrypt = new Encryption($key1, $key2);
        $uncrypted = $encrypt->decode($res['password']);
        $token = md5(uniqid($login, true));

        $newip = $this->ip->checkIp();


        if ($checkLogMeIn->rowCount() != 0){

            if ($passwd == $uncrypted){

                $checkToken = $this->database->prepare('SELECT token, user_id FROM sessions WHERE user_id = :user_id AND launcher=0');
                $checkToken->execute(array('user_id' => $res['id']));

                if ($checkToken->rowCount() == 0) {

                    $insertToken = $this->database->prepare('INSERT INTO `sessions`(`token`, `user_id`, `ip`, `launcher`, `date`) VALUES (:token, :user_id, :ip, 0, :now)');
                    $insertToken->execute(array('token' => $token, 'user_id' => $res['id'], 'ip' => $newip, 'now' => date('Y-m-d H:i:s')));

                } else {

                    $insertToken = $this->database->prepare('UPDATE sessions SET token=:token WHERE user_id=:user_id AND launcher=0');
                    $insertToken->execute(array('token' => $token, 'user_id' => $res['id']));

                }

                $res = $this->checkUser($token);

                return $res;

            }else{

                $data = array(
                    'exist' => false,
                    'id' => 0,
                    'level' => 0,
                    'banned' => false,
                    'ip' => "",
                    'uuid' => "",
                    'mail' => "",
                    'username' => "",
                    'picture' => "",
                    'token' => "",
                    'status' => "nok",
                );

                return json_encode($data);

            }

        }

    }

    public function updateUuid($uid, $userid){

        $upda = $this->database->prepare('UPDATE users SET uid=:uuid WHERE id=:id');
        $upda->execute(array('uuid' => $uid, 'id' => $userid));

        return true;

    }

    public function checkAdmin($token){

        $this->token = $token;

        if (isset($this->token)){

            $taff = json_decode($this->checkUser($this->token));

            if ($taff->exist){

                if (!$taff->banned){

                    if ($taff->level >= 9){

                        return true;

                    }

                    return false;

                }

                return false;

            }

            return false;

        }

        return false;

    }

    public function recoveryPassword($mail){
        $this->usmail = $mail;
        $checkmail = $this->database->prepare('SELECT * FROM users WHERE email = :usmail');
        $checkmail->execute(array('usmail' => $this->usmail));
        $ck = $checkmail->fetch();

        if ($checkmail->rowCount() == 1) {
            $getalready = $this->database->prepare('SELECT * FROM recovery WHERE users = :usmail AND used = 0');
            $getalready->execute(array('usmail' => $this->usmail));
            $cku = $getalready->fetch();

            if ($getalready->rowCount() == 1){
                $mail = New Mail($this->database);
                $ret = json_decode($mail->exeConfig($this->usmail, $cku['code']));
                if ($ret->status == 200){
                    $data = array(
                        'status' => 200,
                        'message' => 'DONE'
                    );
                    return json_encode($data);
                }else{
                    $data = array(
                        'status' => 500,
                        'message' => $ret->message
                    );
                    return json_encode($data);
                }
            }else{
                $code = rand();
                $preprecovery = $this->database->prepare('INSERT INTO recovery (users, code, date_create,used) VALUES (:usmail,:code,now(),0)');
                $preprecovery->execute(array('usmail' => $this->usmail, 'code' => $code));
                $mail = New Mail($this->database);
                $ret = json_decode($mail->exeConfig($this->usmail, $code));
                if ($ret->status == 200){
                    $data = array(
                        'status' => 200,
                        'message' => 'DONE'
                    );
                    return json_encode($data);
                }else{
                    $data = array(
                        'status' => 500,
                        'message' => $ret->message
                    );
                    return json_encode($data);
                }
            }
        }else{
            $data = array(
                'status' => 404,
                'message' => "0 Résultats"
            );
            return json_encode($data);
        }
    }

    public function ckrecoveryPassword($code){
        $ccode = $this->database->prepare('SELECT * FROM recovery WHERE code = :cc');
        $ccode->execute(array('cc' => $code));
        $cccode = $ccode->fetch();
        if ($ccode->rowCount() == 1){
            if ($cccode['used'] != 1){
                $d = array(
                    'status' => 200
                );
                return json_encode($d);
            }else{
                $d = array(
                    'status' => 200
                );
                return json_encode($d);
            }
        }else{
            $d = array(
                'status' => 404
            );
            return json_encode($d);
        }
    }

    public function changePasswdRec($code, $password, $password1){
        $ck = $this->database->prepare('SELECT * FROM recovery WHERE code = :cc');
        $ck->execute(array('cc' => $code));
        $stu = $ck->fetch();
        if ($stu['used'] != 1){
            $cku = $this->database->prepare('SELECT * FROM users WHERE email = :us');
            $cku->execute(array('us' => $stu['users']));
            $std = $cku->fetch();
            $id = $std['id'];
            if ($ck->rowCount() == 1) {
                if ($password == $password1) {
                    $dcryptnow = new Encryption($GLOBALS['key1'], $GLOBALS['key2']);
		            $savlvation = $dcryptnow->encode($password);
		            $savlvation1 = $savlvation;
                    $cki = $this->database->prepare('UPDATE users SET password=:passwd WHERE id=:id');
                    $d = [
                        'res' => $cki->execute(array('passwd' => $savlvation1, 'id' => $id)),
                        'status' => 20
                    ];
                    $cke = $this->database->prepare('UPDATE recovery SET used=:used WHERE code=:cc');
                    $cke->execute(array('used' => 1 ,'cc' => $code));
                    return json_encode($d);
                }else{
                    $d = [
                        'res' => false,
                        'status' => 50
                    ];

                    return json_encode($d);
                }
            }
        }else{
            $d = [
                'res' => false,
                'status' => 30,
                'message' => 'Already Used !'
            ];

            return json_encode($d);
        }
        

        $st = array(
            'res' => false
        );

        return json_encode($st);
    }

    public function changePasswd($id, $actual, $new, $confnew){
        $ck = $this->database->prepare('SELECT password FROM users WHERE id = :id');
        $ck->execute(array('id' => $id));
        $st = $ck->fetch();

        if ($actual == $st[0]) {
            if ($new === $confnew) {
                $cki = $this->database->prepare('UPDATE users SET password=:passwd WHERE id=:id');
                $d = [
                    'res' => $cki->execute(array('passwd' => $new, 'id' => $id))
                ];
                return json_encode($d);
            }else{
                $d = [
                    'res' => false
                ];

                return json_encode($d);
            }
        }

        return json_encode($st);
    }
}