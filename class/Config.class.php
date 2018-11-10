<?php

class Config {

    private $database;
    private $name;
    private $token;
    private $content;

    public function __construct($database){
        $this->database = $database;
    }

    private function checkuser($token){

        $this->token = HtmlSpecialChars($token);

        $check = $this->database->prepare('SELECT user_id FROM sessions WHERE token = :token');
        $check->execute(array('token' => $this->token));
        $res = $check->fetch();
        if ($check->rowCount() != 0 && $checklevel = $this->database->prepare('SELECT `level`,`banned` FROM users WHERE id = :id'))
        {
            $checklevel->execute(array('id' => $res['user_id']));
            $res = $checklevel->fetch();
            if ($checklevel->rowCount() != 0 && (int)$res['level'] >= 9 && (int)$res['banned'] != 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public function get($name){
        $this->name = HtmlSpecialChars($name);
        $getkey = $this->database->query('SELECT * FROM settings');
        $ris = $getkey->fetch();

        return $ris[$this->name];
        /*echo json_encode(var_dump($ris[$name]));*/
    }

    public function set(){

    }

    public function update($paramname, $content, $token){
        $this->name = $paramname;
        $this->content = htmlspecialchars($content);

        if ($this->checkuser($token) === true){
            if (isset($this->name) && $this->name === "site_name"){

                $updatename = $this->database->prepare('UPDATE settings SET site_name=:content WHERE active = 1');
                $updatename->execute(array('content' => $this->content));

                return true;
            }

            if (isset($this->name) && $this->name === "picture"){
                $result = 404;

                return json_encode($result);
            }

            return false;
        }

        return false;
    }

    public function remove(){

    }

}