<?php

class Config {

    private $database;
    private $database1;
    private $name;
    private $token;
    private $content;
    private $content1;
    public $user;


    public function __construct($database){

        $this->database = $database;
        $this->user = new User($database);


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

    public function update($paramname, $content, $content1, $token){

        $this->name = $paramname;
        $this->content = htmlspecialchars($content);
        $this->content1 = htmlspecialchars($content1);
        $this->token = $token;

        if ($this->user->checkAdmin($this->token) === true){

            $update = $this->database->prepare('UPDATE settings SET $this->name = :content WHERE active = 1');

            if (isset($this->name) && $this->name === "site_name"){

                $updatename = $this->database->prepare('UPDATE settings SET site_name=:content WHERE active = 1');
                $updatename->execute(array('content' => $this->content));

                return true;
            }

            if (isset($this->name) && $this->name === "login"){

                $updatelogin = $this->database->prepare('UPDATE settings SET msg_title=:content1, msg_content=:content WHERE active=1');
                $updatelogin->execute(array('content1' => $this->content1, 'content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "maintenance"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET maintenance_title=:content1, maintenance_content=:content WHERE active=1');
                $updatemaintenance->execute(array('content1' => $this->content1, 'content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "max_account"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET max_account=:maccount WHERE active=1');
                $updatemaintenance->execute(array('maccount' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "host_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET host_mail=:mhost WHERE active=1');
                $updatemaintenance->execute(array('mhost' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "username_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET username_mail=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "password_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET password_mail=:content WHERE active=1');
		        $dcryptnow = new Encryption($GLOBALS['key1'], $GLOBALS['key2']);
		        $savlvation = $dcryptnow->encrypt_decrypt('encrypt', $this->content);
		        $this->content = $savlvation;
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "secure_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET secure_mail=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "ports_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET ports_mail=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "sender_mail"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET sender_mail=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "url_website"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET url_website=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            return "not yet";

        }

        return false;

    }
}