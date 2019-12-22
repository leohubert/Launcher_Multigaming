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

            if (isset($this->name) && $this->name === "mail_host"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET mail_host=:mhost WHERE active=1');
                $updatemaintenance->execute(array('mhost' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "mail_username"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET mail_username=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "mail_password"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET mail_password=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "mail_secure"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET mail_secure=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            if (isset($this->name) && $this->name === "mail_port"){

                $updatemaintenance = $this->database->prepare('UPDATE settings SET mail_port=:content WHERE active=1');
                $updatemaintenance->execute(array('content' => $this->content));

                return true;

            }

            return "not yet";

        }

        return false;

    }
}