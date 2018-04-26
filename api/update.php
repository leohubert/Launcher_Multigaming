<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 26/04/2018
 * Time: 03:02
 */


if (isset($_SESSION['level']) && (int)$_SESSION['level'] > 9) {


    $updater = new GitRepository();

    if (!$updater->fetch() || !$updater->pull()) {
        echo json_encode(['status' => 500, 'message' => "Error"]);
        return;
    }

    echo json_encode(['status' => 42, 'message' => "Success !"]);
    return;
}

echo json_encode(['status' => 500, 'message' => "Permissions denied"]);