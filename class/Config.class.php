<?php

class Config {

    private $database;
    private $name;

    public function __construct($database){
        $this->database = $database;
    }

    public function get($name){
        $this->name = $name;
        $getkey = $this->database->query('SELECT * FROM settings');
        $ris = $getkey->fetch();

        return $ris[$this->name];
        /*echo json_encode(var_dump($ris[$name]));*/
    }

    public function set(){

    }

    public function update($paramname, $content){
        $this->name = $paramname;

        if (isset($this->name) && $this->name === "site_name"){

            $updatename = $this->database->prepare('UPDATE settings SET site_name=:content WHERE active = 1');
            $updatename->execute(array('content' => $content));

            $result = 42;

            return json_encode($result);
        }

        if (isset($this->name) && $this->name === "picture"){
            $result = 404;

            return json_encode($result);
        }

        $result['status'] = 404;
        $result['message'] = "Not in conditions";

        return json_encode($result);
    }

    public function remove(){

    }

}