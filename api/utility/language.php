<?php
/*
# ######################### #
# UPDATED BY : FLASHMODZ    #
# UPDATED AT : 04/30/2020   #
# REASON : CREATE i18N API  #
# ######################### #
*/

require_once '../../class/other/i18next.class.php';

header('Content-type: application/json');

if (isset($_POST['lang']) && isset($_POST['var'])) {

    i18next::init($_POST['lang'],'../../lang/__lng__.json');
    $result['status'] = 200;
    $result['message'] = i18next::getTranslation($_POST['var']);
}

echo json_encode($result);