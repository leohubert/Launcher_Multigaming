<?php
/**
 * Created by IntelliJ IDEA.
 * User: FlashModz
 * Date: 01-11-18
 * Time: 14:20
**/

class Autoload{
    /**
     * File extension as a string. Defaults to ".php".
     */
    protected static $fileExt = '.class.php';
    /**
     * The topmost directory where recursion should begin. Defaults to the current
     * directory.
     */
    protected static $pathTop = __DIR__;
    /**
     * A placeholder to hold the file iterator so that directory traversal is only
     * performed once.
     */
    protected static $fileIterator = null;
    /**
     * Autoload function for registration with spl_autoload_register
     *
     * Looks recursively through project directory and loads class files based on
     * filename match.
     *
     * @param string $className
     */
    public static function loader($className)
    {
        $directory = new RecursiveDirectoryIterator(static::$pathTop, RecursiveDirectoryIterator::SKIP_DOTS);
        if (is_null(static::$fileIterator)) {
            static::$fileIterator = new RecursiveIteratorIterator($directory, RecursiveIteratorIterator::LEAVES_ONLY);
        }
        $filename = $className . static::$fileExt;
        foreach (static::$fileIterator as $file) {
            if (strtolower($file->getFilename()) === strtolower($filename)) {
                if ($file->isReadable()) {
                    include_once $file->getPathname();
                }
                break;
            }
        }
    }
    /**
     * Sets the $fileExt property
     *
     * @param string $fileExt The file extension used for class files.  Default is "php".
     */
    public static function setFileExt($fileExt)
    {
        static::$fileExt = $fileExt;
    }
    /**
     * Sets the $path property
     *
     * @param string $path The path representing the top level where recursion should
     *                     begin. Defaults to the current directory.
     */
    public static function setPath($path)
    {
        static::$pathTop = $path;
    }
}
    Autoload::setFileExt('.class.php');
    spl_autoload_register('Autoload::loader');
// EOF