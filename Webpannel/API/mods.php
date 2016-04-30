<?php

listMods("../mods");

function listMods($directory)
{
	if ($handle = opendir($directory)) 
	{
		$Mods = array();
		$i = 0;
		
		/* Listing des mods */
		while (false !== ($entry = readdir($handle))) 
		{
			if ($entry != '.' && $entry != '..')
			{
				$Mods['mod'.$i] = array();
				$Mods['mod'.$i]['name'] = $entry;
				$Mods['mod'.$i]['md5'] = md5_file($directory.'/'.$entry);
				$i++;
			}
			$Mods['total'] = $i;
		}
		closedir($handle);
		echo json_encode($Mods);
	}
}