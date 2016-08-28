<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 17/06/2016
 * Time: 20:36
 */


require '../../class/uploader/Uploader.php';
// Directory where we're storing uploaded images
// Remember to set correct permissions or it won't work
$upload_dir = '../../games/launcher/';
$uploader = new FileUpload('uploadfile');
$uploader->newFileName = 'launcher.' . $uploader->getExtension();
// Handle the upload
$result = $uploader->handleUpload($upload_dir);
if (!$result) {
    exit(json_encode(array('success' => false, 'msg' => $uploader->getErrorMsg())));
}
echo json_encode(array('success' => true));