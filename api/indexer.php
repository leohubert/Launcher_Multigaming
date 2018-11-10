<?php
/**
 * Created by PhpStorm.
 * User: hubert_i
 * Date: 16/06/16
 * Time: 23:16
 */


if (isset($_SESSION['level']) && (int)$_SESSION['level'] == 10) {
    $indexer->getToken();
}

echo json_encode(['message' => "Redirection failed."]);