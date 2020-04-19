<center>
 <img src="https://raw.githubusercontent.com/MrDarkSkil/Launcher_Arma3/master/GFX/icones/favicon.png" width="100px">
<center>
 
# Supported Games
Arma3 - Altis Life / EXILE and more...

## Launcher Information:

#### Last version:
Version: 5.5<br>
Release date: 24/12/2019 01:00 <br>
<br>
Copyright Emodyz © 2014 - 2018<br>

If you have any question or suggestion you can talk with the dev team on Discord:<br>
https://discord.gg/75pQdYx<br>

## Coming soon:  
- Login with forum, facebook, etc ... (XenForo in progress)
- More stats ingame ( gang, total vehicle, total house etc...)
- Donation system

--------------------------------------------------
## Install Command:

- wget https://raw.githubusercontent.com/MrDarkSkil/Launcher_Multigaming/bash-unix/auto-installV5.sh<br>
- chmod +x ./auto-installV5.sh<br>
- ./auto-installV5.sh<br>
--------------------------------------------------

## Creators:

###### Léo Hubert
```json
{
"nom":"Hubert",
"prenom":"Léo",
"email":"leo.hubert@epitech.eu",
"linkedin": "https://www.linkedin.com/in/leohubert"
}
```

###### Jérémy Manet
```json
{
"nom":"Manet",
"prenom":"Jérémy",
"email":"jmanet@underside.be",
"linkedin": "https://www.linkedin.com/in/jeremy-manet-be/"
}
```

### Webpanel Screens :

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824118958653470/Screenshot_2.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824121076514836/Screenshot_3.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824121802129439/Screenshot_4.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824123089911841/Screenshot_5.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824123895349250/Screenshot_6.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824124939599873/Screenshot_7.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824127141478440/Screenshot_8.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659824143365308438/Screenshot_9.png)

![Launcher_Arma3 Logo](https://cdn.discordapp.com/attachments/431901495894605824/659825537849491476/Screenshot_10.png)


## Licences:

##### This project is under GPL licence, please refer to the LICENCE file.

--------------------------------------------------

### Changes Logs:

Release 5.5:
- Add: Lost Password
- Add: Code Security for reset
- Add: Mail Support
- Add: Maximum account
- Update: Refactor many class
- Update: Steam Class
- Fix: Install
- Fix: DB seeding
- Fix: With last compatibility of PHP 7.x

Release 5.4:
- Add: SteamWrapper (Autodetect SteamUID using Steam)
- Add: Support of Windows servers
- Add: Emodyz Support & Analytics to see the evolution of your Community
- Update: Refactor Encrypt for work on PHP7
- Update: Old icons to modern icons ( Flat )
- Fix: Steam Error when click on Start
- Fix: Spacewar in steam status
- Fix: Bugs with PHP7 & PHP5.6 ( Encrypt & SaveConfig)

Release 5.3:
- Add: Support of AltisLife V5 with in game informations
- Remove: LocalPath in create server config
- Fix: Steam Error on start
- Fix: Install WebPanel pages
- Fix: UUID Getter

Release 5.2:
- Add: UUID autodetect
- Remove: UUID in register page (web panel/launcher)
- Fix: UUID register 500 error

Release 5.1:
- Add: Default language in Program.cs to hide language choose page
- Fix: Popup showed when login is disable
- Fix: Some bugs

Release 5.0:
- Add: Multiserver/Games
- Add: New system for update (mods)
- Add: Server section into the panel
- Add: You can lock a server (with password or not)
- Add: You can make a server on maintenance
- Add: File Browser ( for server )
- Add: New Taskforce System
- Add: You can add password server from the pannel
- Remove: IP server adress from launcher (change with mission)
- Fix: Taskforce Installer (userconfig)
- Fix: Reselect server if it does't exist.
- Fix: If website isn't correct
- Fix: If update not create for first time, show error message (nbr_of_server.json in server directory)
- Fix: Some Bugs
- Add: IG (in-game) user information on launcher & panel
- Add: When you ban a player, her ip is automatically banned
- Add: Can delete user on panel
- Add: Auto-Connect to panel with COOKIES
- Add: Support button into launcher whit auto-connection
- Add: Server status (ONLINE / OFFLINE, number of player and more...)
- Add: Lock session into panel
- Add: If an email or an username has more than 20 character on the launcher, we show 20 first character and add ... to this
- Add: Profile view into the panel
- Add: Settings profile into the panel
- Fix: Translate of all launcher (French/English)
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
