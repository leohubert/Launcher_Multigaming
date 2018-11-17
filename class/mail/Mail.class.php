<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 17-11-18
 * Time: 23:47
 */

class Mail{

    private $database;
    private $config;
    private $sender;
    private $to;
    private $type;
    private $content;


    public function __construct($database){

        $this->database = $database;
        $this->config = new Config($this->database);

    }

}