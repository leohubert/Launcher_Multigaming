<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 17/06/16
 * Time: 17:19
 */


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['id'])) {
    $id = $_POST['id'];

    $getSettings = $database->prepare('SELECT * FROM `servers` WHERE id = :id');
    $getSettings->execute(array('id' => $id));
    if ($getSettings->rowCount() != 0)
    {
        $res = $getSettings->fetch();
        $taskforce_directory = $res['local_path'] . "/taskforce";
        function get_filelist_as_array($dir, $recursive = true, $basedir = '')
        {
            if ($dir == '') {
                return array();
            } else {
                $results = array();
                $subresults = array();
            }
            if (!is_dir($dir)) {
                $dir = dirname($dir);
            } // so a files path can be sent
            if ($basedir == '') {
                $basedir = realpath($dir) . DIRECTORY_SEPARATOR;
            }

            $files = scandir($dir);
            foreach ($files as $key => $value) {
                if (($value != '.') && ($value != '..')) {
                    $path = realpath($dir . DIRECTORY_SEPARATOR . $value);
                    if (is_dir($path)) { // do not combine with the next line or..
                        if ($recursive) { // ..non-recursive list will include subdirs
                            $subdirresults = get_filelist_as_array($path, $recursive, $basedir);
                            $results = array_merge($results, $subdirresults);
                        }
                    } else { // strip basedir and add to subarray to separate file list
                        $subresults[] = str_replace($basedir, '', $path);
                    }
                }
            }
            // merge the subarray to give the list of files then subdirectory files
            if (count($subresults) > 0) {
                $results = array_merge($subresults, $results);
            }
            return $results;
        }

        $files = get_filelist_as_array($taskforce_directory);
        $result['total'] = count($files);
        $result['status'] = 42;
        $result['message'] = "Taskforce files showed ! ";
        $result['files'] = array();
        $i = 0;
        while ($i < $result['total']) {
            $result['files'][$i]['name'] = $files[$i];
            $result['files'][$i]['size'] = filesize($taskforce_directory . '/' . $files[$i]);
            $result['files'][$i]['md5'] = md5_file($taskforce_directory . '/' . $files[$i]);
            $i++;
        }
    }
    else
    {
        $result["status"] = 44;
        $result["message"] = "Server not found";
    }
}
else
{
    $result["status"] = 404;
    $result["message"] = "Arguments missing.";
}

echo json_encode($result);