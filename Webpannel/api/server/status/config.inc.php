<?php

include_once ('../../../configs/config_general.php');

//change this to reflect the servers that you want to query
$servers = array(
	array(
		'id' => $site,
		'type' => 'armedassault3',
		'host' => $arma_ip . ':' . $arma_port,
	)
);
