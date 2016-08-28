<?php
/**
 * Created by PhpStorm.
 * User: Hubert Léo
 * Date: 19/06/2016
 * Time: 17:45
 */

function change_config_file_settings ($filePath, $newSettings) {

    // Get a list of the variables in the scope before including the file
    $old = get_defined_vars();

    // Include the config file and get it's values
    include($filePath);

    // Get a list of the variables in the scope after including the file
    $new = get_defined_vars();

    // Find the difference - after this, $fileSettings contains only the variables
    // declared in the file
    $fileSettings = array_diff($new, $old);

    // Update $fileSettings with any new values
    $fileSettings = array_merge($fileSettings, $newSettings);

    // Build the new file as a string
    $newFileStr = "<?php\n\n";
    foreach ($fileSettings as $name => $val) {
        // Using var_export() allows you to set complex values such as arrays and also
        // ensures types will be correct
        $newFileStr .= "\${$name} = " . var_export($val, true) . ";\n";
    }
    // Closing tag intentionally omitted, you can add one if you want

    // Write it back to the file
    file_put_contents($filePath, $newFileStr);

}


header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");


if (isset($_POST['status']))
{

// Example usage:
// This will update $dbuser and $dbpass but leave everything else untouched

    if ($_POST['status'] == "true")
    {
        $newSettings = array(
            'ig_info' => true,
        );
    }
    else
    {
        $newSettings = array(
            'ig_info' => false,
        );
    }

    change_config_file_settings('configs/config_general.php', $newSettings);
    $result['status'] = 42;
    $result['message'] = "Successfully switched";
}
else
{
    $result["status"] = 404;
    $result["message"] = "Missing fields";
}

echo json_encode($result);

