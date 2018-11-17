<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 18-11-18
 * Time: 00:02
 */

class Exception extends \ErrorException
{
    /**
     * Prettify error message output.
     *
     * @return string
     */
    public function errorMessage()
    {
        return '<strong>' . htmlspecialchars($this->getMessage()) . "</strong><br />\n";
    }
}