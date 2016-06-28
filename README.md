![alt text](https://raw.githubusercontent.com/MrDarkSkil/Launcher_Arma3/master/GFX/icones/favicon.png "Logo Launcher")
# Launcher_Arma3
Launcher_Arma3 

###Launcher Information:

####Last push:
Version: Beta 5.0.4.0
Functional: YES
Release date: 23/06/2016 22:40


####Last functional version:
Version: Release 4.0.0.0
Functional: YES
Release date: 30/04/2016 à  14:20

Copyright HUBERT Léo © 2014 - 2016

### Launcher Panel Guide Intall:

For install this panel you need to have a little VPS 
or more biggest.

Minimal config required: https://www.ovh.com/fr/vps/vps-ssd.xml 

When you have a VPS or other, connect to that with SSH (on windows with PUTTY on linux with "ssh" command)
Once connected, follow step by step.


- Step 1: 
Write this command in the terminal 'apt-get update; apt-get upgrade'
- Step 2: 
Write this command in the terminal 'apt-get install apache2 php5 php5-curl'
- Step 3: 
Write this command in the terminal 'apt-get install mysql-server' and follow install page.  
- Step 4: 
Write this command in the terminal 'apt-get install phpmyadmin' and follow install page.
- Step 5: 
Edit this file (/etc/apache2/apache2.conf) with this command 'sudo nano /etc/apache2/apache2.conf'
search this line:
"
  <Directory /var/www/>
    Options Indexes FollowSymLinks
    AllowOverride None
    Require all granted
  </Directory>
"
edit to
"
  <Directory /var/www/>
    Options Indexes FollowSymLinks
    AllowOverride All
    Require all granted
  </Directory>
"
- Step 6: 
Write this command in the terminal 'sudo a2enmod rewrite'
- Step 7: 
Upload WebPanel to the /var/www/html folder (don't forget .htaccess file)

###Creators:

######Léo Hubert
```json
{
"nom":"Hubert",
"prenom":"Léo",
"email":"leo.hubert@epitech.eu", 
"linkedin": "https://www.linkedin.com/in/leohubert"
}
```

###Licences:

#####This project is under GPL licence, please refear to the LICENCE file.

--------------------------------------------------


###Changes Logs:

Beta 5.0.4.0:
- Add: Panel news control
- Add: Arma3 automatic search
- Add: TeamSpeak automatic search
- Add: Create support with player ( admin )
- Add: All users pages ( admins, banned )
- Add: TaskForce settings
- Add: TaskForce into launcher (BETA)
- Add: API for taskforce
- Fix: User name register fix
- Fix: Install error (mysql_connect.php)
And more ....

-----------------------------------

Launcher update v0.0.1.3:
- Add: Admin create support
- Add: List of admins
- Add: List of banned
- Fix: Update player permission

-----------------------------------

Launcher update v0.0.1.0:
- Add: AutoInstall page
- Fix: Register page
- Fix: Settings page
And more...

------------------------------------

Alpha 5.0.3.0:
- Add: New panel
- Add: New api
- Add: Maintenance on live (maintenance edit on live)
- Add: Maintenance picture possibilities
- Add: Support with direct chat on new panel.
- Add: Steam UID for prepare statistique about in game account
- Update: Update Launche with new api
And more, more, more ...

------------------------------------

Pre-Alpha 5.0.2.0:
- Add: Image news on login form
- Add: Estimed time download
- Add: Downloaded mods size
- Add: Prepare download progress bar
- Add: Panel options settings
- Add: New design settings form
- Add: Pause download
- Add: Cancel download
- Add: Reset modspack button (in settings)
- Add: Change language button (in settings)
- Add: Arma3 Launch options (in settings)
- Add: Admin account for panel (email: ownerdemo pass: ownerdemo123A)
- Fix: Launcher update (destination with space)
- Fix: Change language closing form
And more ...

------------------------------------

Pre-Alpha 5.0.1.5:
- New downloading system
- More speed download
- Listing mods,cpp and other file with md5
- Add: API download system
- Add: API listing addons and another file
- FIX: API Install system
- Add: Autoinstall script bash.

------------------------------------

Building 5.0.1.0:
- New design for login and register.
- Add: register system
- Prepare to add auto update launcher

-------------------------------------

Building 5.0.0.3:
- Add: News system
- Add: Auto connexion
- Add: MetroFramework
- Add: New API system (Wirk)
- Add: Pannel v2.0
 
-------------------------------------

Building 5.0.0.2:
- Add: Login system
- Prepare: News System
- Add: API register ( Wirk )

-------------------------------------

Building 5.0.0.1:
- New: Launcher (not functional).
- Add: WebPanel Admin
- Add: API
- Add: Login system

--------------------------------------

Clean Repo:
Remove the old version
sure to start anew.

The v4.0.0.0 be downloaded in
left "release" at github.com/MrDarkSkil/Launcher_Arma3 

--------------------------------------

Release 4.0.0.0:
Prepare for the v5.0.0.0 update

Future additions:
Pannel Admin
API
New download system
Login system ( deactivate )
Multiple serveur function

--------------------------------------

Release 3.0.0.0:
- Add: Force Update.
- Fix: Error 405.
- Change: Button link.
- Preparation: Anti-Cheat Arma 3.
- Preparation: Download .zip or .rar mods.

--------------------------------------

Pre-Release 2.9.3.0:
- Fix: Checking if TaskForce is already installed.
- Fix: When you reset the mods, mods that retÃ©lÃ©charge (not before)
- Optimization: Optimization translation system.
(Preparation of changing the script to download the mods)
--------------------------------------

Release 2.5.1.0:
- Add: Verify the version of mods.
- Add: Options to activate changelogs
- Fix: Bug music off base
- Fix: Bug launching arma3 after going through the options
- Fix: Bug launch TeamSpeak 3 after installing TaskForce
- Fix: Bug display the translation of changelogs Panel
- Fix: Bug Changelogs reversed.

--------------------------------------

Release_2.0.0.0:
- Fix: Bug Taskforce (TS3 destination).
- Fix: Bug when the music is off base.
- Change: Stop the music when it launches Arma3.
- Add: Changelogs system.
- Add: System maintenance with online image.
- Add: Translation system TaskForce
- Add: translation of Fischer.

--------------------------------------

Release_1.0.0.0:
- Add: Taskforce Radio Install
- Add: Reset Button mods (removes all the mods)
- Add: Introductory Music (option "on, off")
- Add: music management settings
- Add: Options Arma3 launch when the download is finished.
- Add Download the CPP files.

--------------------------------------

Beta_2.0.0.0:
( last BETA ! )
- Add: The Italian language is supported by the launcher
- Add: The Chinese language is supported by the launcher
- Fix: The launcher options are 100% functional
- Add: Language selection Memory
- Add: UserName set via the options in the launcher
- Add: Launch Options add option Panel launcher
- Fix: Lanteur the launch of the launcher
- Fix: Bug download blocking mods

--------------------------------------

Beta_1.5.0.0:
- Add: download information (bytesdownloaded / total bytes).
- Add: Download mods information (modsname).
- Add: System news.
- Change: Start Arma3 options.
- Change: Download download Progress Bar (Bar right progression).
- Fix: Error message when the launcher opens

--------------------------------------

Beta_1.0.0.0:
- Add: Launch of arma3 when the download is finished mods
- Change: XML translate error
- Change: XML translate launcher
- Add: System offline launcher
- Add: Several error messages

Thanks to beta testers who warned me good
operation of the launcher and warned of several bugs.

--------------------------------------

Beta_0.0.2.0:
- Add: Banner error instead of popup messages
- Add: XML translate error
- Add: Animation fader + option "on / off"

--------------------------------------

beta_0.0.0.1:
- Add: Download mods
- Add: Checking mods
- Add: AutoUpdate mods

--------------------------------------

building_0.0.3.0:
- Add: With Translate XML file
- Add: Icon arma 3 if the destination is correct or not.
- Add: Upload FTP folder for building testers.

--------------------------------------

building_0.0.2.75:
- Add: Destination script

--------------------------------------

building_0.0.2.5:
- Add: Launcher Settings
- Add: German language.

--------------------------------------

building_0.0.2.0:
- Update Launcher 100% Functional!
- Fixed several bugs.
- Add: Launcher Updater Program
--------------------------------------

building_0.0.1.6:

+ Update Launcher
+ Fix bugs
