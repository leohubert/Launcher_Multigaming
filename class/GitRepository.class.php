<?php

class GitRepository
{
    /**
     * GitRepository constructor.
     */
    public function __construct()
    {
    }


    /**
     * @param null $command
     * @return string
     * @throws Exception
     */
    private function execute($command = null){
        if(!$command){
            throw new Exception("No command given");
        }
        // If windows, else
        if (strtoupper(substr(PHP_OS, 0, 3)) === 'WIN') {
            return system($command);
        }else{
            return shell_exec($command);
        }
    }

    /**
     * @return bool
     */
    public function checkForUpdates()
    {
        $file = 'games/lastUpdate.txt';
        $lastUpdate = file_get_contents($file);
        if ($lastUpdate) {
            $lastUpdate = new \DateTime($lastUpdate);
            $currentTime = new \DateTime();
            try {
                $lastUpdate->add(new \DateInterval('PT1H'));
            } catch (\Exception $e) {
                return false;
            }
            if ($lastUpdate < $currentTime) {
                try {
                    $this->execute('git fetch');
                } catch (Exception $e) {
                    return false;
                }

                $now = (new \DateTime())->format('Y-m-d\TH:i:s.u');
                file_put_contents($file, $now);
            }
        } else {
            $now = (new \DateTime())->format('Y-m-d\TH:i:s.u');
            file_put_contents($file, $now);
        }
        try {
            $output = $this->execute('git status');
        } catch (Exception $e) {
            return false;
        }
        if (strstr($output, 'up to date ') === false && strstr($output, 'up-to-date ') === false) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * @return bool
     */
    public function pull() {
        try {
            $this->execute('git pull');
        } catch (Exception $e) {
            return false;
        }
        return true;
    }

    /**
     * @return bool
     */
    public function fetch() {
        try {
            $this->execute('git fetch');
        } catch (Exception $e) {
            return false;
        }
        return true;
    }
}