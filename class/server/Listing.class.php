<?php

class Listing {

    public  $allow_ext,
            $file_prefix,
            $allowed_extensions,
            $ignore_hidden,
            $prefix,
            $cpp,
            $addons,
            $exclude_dir;
    private $srvid,
            $admin,
            $database,
            $filter;
    

    public function __construct($database){
        
        $this->database = $database;
        $this->setFilter();
        date_default_timezone_set(@date_default_timezone_get());
    }

    public function setSrv($id){

        $this->srvid = $id;
        $getSettings = $this->database->prepare('SELECT * FROM servers WHERE id = :id');
        $getSettings->execute(array('id' => $this->srvid));
        $ressrv = $getSettings->fetch();
        $data = array(
            'name' => $ressrv['name'],
            'modversion' => $ressrv['vmod'],
            'taskforce' => $ressrv['taskforce'],
            'taskforceversion' => $ressrv['vtaskforce'],
            'path' => $ressrv['local_path'],
            'pathaddons' => $ressrv['local_path'] . '/modpack/addons',
            'pathcpps' => $ressrv['local_path'] . '/modpack',
            'modpack' => $ressrv['modpack_name'],
            'ip' => $ressrv['ip'],
            'port' => $ressrv['port'],
            'game' => $ressrv['game'],
        );

        return json_encode($data);
    }

    public function setFilter(
        $allowed_extensions = array('*'),
        $file_prefix = '',
        $exclude_dir = array(),
        $ignore_hidden = true
    ){

        $this->allowed_extensions = $allowed_extensions;
        $this->file_prefix = $file_prefix;
        $this->ignore_hidden = $ignore_hidden;
        $this->exclude_dir = $exclude_dir;
    }

    public function buildTree($server){
        $dir = new RecursiveDirectoryIterator(
            $server->path, FilesystemIterator::SKIP_DOTS);

        $this->filter($dir);
        $it = new RecursiveIteratorIterator(
            $this->filter,
            RecursiveIteratorIterator::SELF_FIRST,
            RecursiveIteratorIterator::CATCH_GET_CHILD
        );
    
        $tree = array();
        foreach($it as $fileinfo) {
        
            $name = $fileinfo->getFilename();
            $sub_path_name = $it->getSubPathName();
            $parts = explode(DIRECTORY_SEPARATOR, $sub_path_name);
            array_pop($parts);
        
            $parentArr = &$tree;
        
            //go deep in the file|dir path
            foreach ($parts as $part) {
                $parentArr = &$parentArr['dirs'][$part];
            }
        
            if ($fileinfo->isDir()) {
                // Add the final part to the structure
                $parentArr['dirs'][$name] = array('folder' => $name);
            } else {
                // Add some file info to the structure
            
                if($fileinfo->isLink()){
                    $realpath = $fileinfo->getRealPath();
                    $filesize = filesize($realpath);
                    $filemtime = filemtime($realpath);
                } else {
                    $filesize = $fileinfo->getSize();
                    $filemtime = $fileinfo->getMTime();
                }
            
                $parentArr['files'][] = array(
                    'filename'          => $name,
                    'md5'               => md5_file($fileinfo),
                    'filesize'          => $this->fileSizeConvert($filesize),
                    'date'              => date("d-m-Y H:i", $filemtime),
                    'relative_path'     => $it->getSubPath()
                );
            }
        }
        unset($parentArr);
        $this->sortArray($tree);
        return $tree;
    }

    private function sortArray(&$tree){
        foreach ($tree as &$value) {
            if (is_array($value))
                $this->sortArray($value);
        }
        return ksort($tree);
    }

    public function saveJSON($path, $filename){
        $tree = $this->buildTree();
        $path = realpath($path);
        if($path && is_writable($path)){
            $full = $path .DIRECTORY_SEPARATOR. $filename;
            $write = file_put_contents($full, json_encode($tree));
            
            if($write)
                echo 'Saved: ' . $full . "\n";
            else
                echo 'Error trying to save: ' . $full . "\n";
        }
    }

    public function getJSON(){
        header('Content-Type: application/json');
        echo json_encode(array(
            'tree' => $this->buildTree()
        ));
    }

    private function filter($dir){
    
        $this->filter = new RecursiveCallbackFilterIterator($dir, 
            function($current, $key, $iterator){
                $filename = $current->getFilename();
            
                //ignore all hidden files/directories
                if($this->ignore_hidden){
                    if(substr($filename, 0, 1) == '.')
                        return false;
                }
            
                // Allow recursion
                if($iterator->hasChildren() && 
                    !in_array($filename, $this->exclude_dir)) {
                    return true;
                }
                
                if($current->isReadable() === false)
                    return false;
                
                    
                //filter by file extension
                $path = $current->getPathname();
                $file_ext = pathinfo($path, PATHINFO_EXTENSION);
                
                if($this->allowed_extensions[0] == '*'){ //no extension filter
                    $ext_allowed = true;
                } else {
                    $ext_allowed = in_array($file_ext, $this->allowed_extensions);
                }
                
                if(!empty($this->file_prefix)){
                    //filter by prefix and extension
                    if(strpos($filename, $this->file_prefix) === 0 && $ext_allowed)
                        return true;
                    else
                        return false;
                }
                
                //filter by extension
                return $ext_allowed;
            }
        );
    }

    public function fileSizeConvert($bytes){
        $label = array('B', 'KB', 'MB', 'GB', 'TB', 'PB');
        for($i = 0; $bytes >= 1024 && $i < (count($label) -1); $bytes /= 1024, $i++);
        return round($bytes, 2) . " " . $label[$i];
    }

}