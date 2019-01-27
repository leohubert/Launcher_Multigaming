#!/bin/bash

echo -e '\n \e[39m'$checkdep
sudo apt update && sudo apt upgrade -y
echo -e '\n \e[91m'$checkdist
sudo apt update && sudo apt dist-upgrade -y
			
cd /tmp
ls
wget https://dev.mysql.com/get/mysql-apt-config_0.8.11-1_all.deb
echo -e '\n \e[91m'$donotforgetv
sleep 2
sudo dpkg -i mysql-apt-config*
sudo apt update
cd /
			
sleep 10
sudo apt install apache2 unzip php7.0 php7.0-mysql php7.0-curl git
sudo apt install mysql-server
sudo apt install phpmyadmin
sudo apt install libfcgi-dev libfcgi0ldbl libjpeg62-turbo-dev libmcrypt-dev libssl-dev libc-client2007e libc-client2007e-dev libxml2-dev
sudo apt install libbz2-dev libcurl4-openssl-dev libjpeg-dev libpng-dev libfreetype6-dev libkrb5-dev libpq-dev libxml2-dev libxslt1-dev
sleep 5
			
sed -i '/<Directory "\/var\/www\/html">/,/<\/Directory>/ s/AllowOverride None/AllowOverride all/' /etc/apache2/apache2.conf
sudo a2enmod rewrite
sudo service apache2 restart
sudo rm -rf /var/www/html
cd /var/www && git clone https://github.com/MrDarkSkil/Launcher_Multigaming.git -b webpanel-test html
chown -R www-data:www-data /var/www/html/games/
chmod -R 777 /var/www/html/configs/
			
echo -e '\n \e[92m'$successinstall
echo -e '\n \e[92m'$successinstalladress
exit 0;
