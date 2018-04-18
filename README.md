<center>
 <img src="https://raw.githubusercontent.com/MrDarkSkil/Launcher_Arma3/master/GFX/icones/favicon.png" width="100px">
<center>
 
# Supported Games
Arma3 - Altis Life / EXILE and more...

## Launcher Information:

#### Last version:
Version: 5.2<br>
Release date: 28/02/2017 19:24 <br>
<br>
Copyright HUBERT Léo © 2014 - 2018<br>

If you have any question or suggestion you can talk with the dev team on Discord:<br>
https://discord.gg/75pQdYx<br>

You can follow the new launcher here:<br>
https://github.com/emodyz/launcher-ezgames.eu

## Coming soon:  
- Login with forum, facebook, etc ... (XenForo in progress)
- More stats ingame ( gang, total vehicle, total house etc...)
- Donation system
- Profile editing (in launcher)

## Launcher Panel Install Guide:

En Français: https://github.com/MrDarkSkil/Launcher_Multigaming/wiki/Intall-guide-for-DEBIAN-8-%5BFR%5D<br>
In English:  https://github.com/MrDarkSkil/Launcher_Multigaming/wiki/Intall-guide-for-DEBIAN-8-%5BEN%5D<br>

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

### Launcher Screens:

![Launcher_Arma3 Logo](Screens/release/release_5.4/laucher/login.PNG)

![Launcher_Arma3 Logo](Screens/release/release_5.4/laucher/register.PNG)

![Launcher_Arma3 Logo](Screens/release/release_5.4/laucher/launcher.PNG)

![Launcher_Arma3 Logo](Screens/release/release_5.4/laucher/server-choose.PNG)

### Webpanel Screens :

![Launcher_Arma3 Logo](Screens/release/release_5.4/webpanel/login.PNG)

![Launcher_Arma3 Logo](Screens/release/release_5.4/webpanel/server-settings.PNG)

![Launcher_Arma3 Logo](Screens/release/release_5.4/webpanel/user-list.PNG)




## Licences:

##### This project is under GPL licence, please refer to the LICENCE file.

--------------------------------------------------

### Changes Logs:

Release 5.4:
- Add: SteamWrapper (Autodetect SteamUID using Steam)
- Add: Support of Windows servers
- Add: Emodyz Support & Analytics to see your server evoluting
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
