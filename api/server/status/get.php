<?php
   error_reporting(0);
require_once ("gameq/src/GameQ/Autoloader.php");

header('Content-type: application/json');

$result = array("status" => 500, "message" => "Internal error");

if (isset($_POST['name']) && isset($_POST['arma_ip']))
{
    $servers = array(
        array(
            'id' => $_POST['name'],
            'type' => 'armedassault3',
            'host' => $_POST['arma_ip'],
        )
    );

	// Call the class, and add your servers.
	$gq = \GameQ\GameQ::factory();
	$gq->addServers($servers);

	// You can optionally specify some settings
	$gq->setOption('timeout', 3); //in seconds

	// Send requests, and parse the data
	$results = $gq->process();

	//iterate through each server
	foreach ($results as $key => $server)
	{
		//the server is online and running
		if ($server['gq_online'])
		{
			$result['status'] = 42;
			$result['server_name'] = $key;
			$result['server_hostname'] = $server['gq_hostname'];
			$result['server_map'] = $server['gq_mapname'];
			$result['server_ip'] = $server['gq_address'];
			$result['server_port'] = $server['port'];
			$result['server_mission'] = $server['game_descr'];
			$result['server_type'] = $server['gq_gametype'];
			$result['server_onlineplayers'] = $server['gq_numplayers'];
			$result['server_maxplayers'] = $server['gq_maxplayers'];
			$result['online'] = true;
			$result['message'] = "Server ONLINE";
		} else {
			$result['status'] = 42;
			$result['server_name'] = $key;
			$result['online'] = false;
			$result['message'] = "Server OFFLINE";
		}
	}
}

echo json_encode($result);


