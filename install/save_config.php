<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 17:45
 */

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['server_name']) && isset($_POST['token']) && isset($_POST['analytics']))
{

// Example usage:
// This will update $dbuser and $dbpass but leave everything else untouched


    $config = parse_ini_file( 'configs/config_general.php' );

    $config[ 'is_config' ] = true;
    $config[ 'site' ] = $_POST['server_name'];
    $config[ 'encrypt_key' ] = $_POST['token'];
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
}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);

