<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 17:45
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");
include dirname(__FILE__) . '/../configs/mysql_connect.php';


if (isset($_POST['server_name'])  && isset($_POST['analytics']) && isset($_POST['token1']) && isset($_POST['token2']))
{

// Example usage:
// This will update $dbuser and $dbpass but leave everything else untouched

    $config = parse_ini_file( 'configs/config_general.php' );

    $config[ 'is_config' ] = true;
    if (isset($_POST['server_name'])){
        $config[ 'site' ] = $_POST['server_name'];
    }else{
        $config[ 'site' ] = $_POST['server_name_hide'];
    }
    $config[ 'encrypt_key1' ] = $_POST['token1'];
    $config[ 'encrypt_key2' ] = $_POST['token2'];
    $config[ 'analytics' ] = $_POST['analytics'] == 'true' ? true : false;


    $f = fopen( "configs/config_general.php", "w" );
    fwrite( $f, "<?php\n" );
    foreach ( $config as $name => $value )
    {
        if (is_bool($value)) {
            fwrite( $f, "$$name = " . ($value == true ? 'true' : 'false') .";\n" );
        } else {
            fwrite( $f, "$$name = \"$value\";\n" );
        }
    }

    fclose( $f );
    $indexer->installFinished($config[ 'analytics' ]);
    $result['status'] = 42;
    $result['message'] = "Successfully saved";


    if ($config['analytics'] == true){
        $updateindexer = $database->prepare('UPDATE settings SET indexer=1');
        $updateindexer->execute();
    }else{
        $updateindexer = $database->prepare('UPDATE settings SET indexer=0');
        $updateindexer->execute();
    }

    $updatesettings = $database->prepare('UPDATE settings SET site_name=:sitename');
    $updatesettings->execute(array('sitename' => $config[ 'site' ]));
}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);

