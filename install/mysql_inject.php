<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 18/06/2016
 * Time: 07:40
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['db_host']) && isset($_POST['db_name']) && isset($_POST['db_user']) && isset($_POST['db_pass'])
    && $_POST['db_host'] != "" && $_POST['db_name'] != "" && $_POST['db_user'] != "")
{
    try {
        $database = new PDO('mysql:host='. $_POST['db_host'] .';dbname='. $_POST['db_name'], $_POST['db_user'], $_POST['db_pass']);
        $sql = implode(array_map(function ($v) {
            return file_get_contents($v);
        }, glob(__DIR__ . "/*.sql")));
        $qr = $database->exec($sql);
        $file = fopen("configs/config_mysql.php", "w+") or die("Unable to open file!");
        fwrite($file, '<?php' . PHP_EOL);
        fwrite($file, '$mysql_host = "'. $_POST['db_host'] .'";' . PHP_EOL);
        fwrite($file, '$mysql_user = "' . $_POST['db_user'] .'";' . PHP_EOL);
        fwrite($file, '$mysql_pass = "' . $_POST['db_pass'] .'";' . PHP_EOL);
        fwrite($file, '$mysql_dbname = "' . $_POST['db_name'] .'";' . PHP_EOL);
        fclose($file);
        $indexer->registerApp();
        $result['status'] = 42;
        $result['message'] = "Injection successfully";
    } catch (PDOException $e) {
        $result['status'] = 01;
        $result['message'] = $e->getMessage();
    }
}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);
