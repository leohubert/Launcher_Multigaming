#!/bin/bash

lang=$(locale | grep LANG | cut -d= -f2 | cut -d_ -f1)

os=''
ost=''
vers=''
auth=''

## GITHUB INFO
guser='MrDarkSkil'
grepo='Launcher_Multigaming'
gbranch='bash-unix'

function jumpto {
    	label=$1
    	cmd=$(sed -n "/$label:/{:a;n;p;ba};" $0 | grep -v ':$')
    	eval "$cmd"
    	exit 0
}

if [[ $lang == 'fr' ]]; then
	function ask_y_or_n() {
		read -p 'Demande du serveur Emodyz ([O]ui ou [N]on): '
		case $(echo -e $REPLY | tr '[A-Z]' '[a-z]') in
		o|O|oui) echo 'oui';;
		*) echo 'non';;
		esac
	}

	#Before Install
	confirm='Merci de confirmer votre choix'
	installprog='Merci d avoir accepter, nous effectuons l installation \n soyez patient :) \n \n \e[95mL equipe EMODYZ'
	a=' \n  \e[95mBienvenu(e) sur le script auto-install de la V5 \n \e[97mnous vous demanderons de choisir certaines option \n qui nous permet ainsi de determiner les meilleurs paramètres pour vous. \n .. \n \e[91mSoyez le plus attentif possible et consencieux dans vos réponse ...'
	b=' \n \e[95mEmodyz vérifie votre OS et votre configuration, veuillez patienté ...'
	
	#During Install
	checkdep='Nous vérifions les dépendances ...'
	checkdist='Nous vérifions et mettons à jour votre distribution ..'
	donotforgetv='N oubliez pas de bien séléctionner la Version 5.7 puis OK !!!!'

	#Install Success
	successinstall='Installation Finalisé avec Succès !'
	successinstalladress='Ouvrez un nouvel onglet dans votre navigateur \n \n Mettez-y l adresse IP de votre serveur \n \n ENJOY !!'

	#Error
	notimpl='N a pas été implémenté pour le moment, soyez patient :)'
	cancel='Vous avez annulé la procédure, vous n avez pas acceptez que EMODYZ effectue l installation automatiquement...'
fi

if [[ $lang == 'en' ]]; then
	function ask_y_or_n() {
		read -p 'Request Emodyz Server ([Y]es or [N]o): '
		case $(echo $REPLY | tr '[A-Z]' '[a-z]') in
		y|Y|yes) echo 'yes';;
		*) echo 'no';;
		esac
	}

	#Before Install
	confirm='Please confirm your choice'
	installprog='Thank you for accepting, we are doing the installation \n be patient :) \n \n \e[95mThe EMODYZ team'
	a=' \n  \e[95mWelcome to the auto-install script of the V5 \n \e[97mwe will ask you to choose some option \n which allows us to determine the best parameters for you. \n .. \n \e[91mBe as attentive as possible and conscientious in your answers ...'
	b=' \n \e[95mEmodyz checks your OS and your configuration, please wait ...'

	#During Install
	checkdep='We check dependencies ...'
	checkdist='We check and update your distribution ..'
	donotforgetv='Do not forget to select Version 5.7 and OK !!!!'

	#Install Success
	successinstall='Installation Finalized with Success !'
	successinstalladress='Open a new tab in your browser \n \n Put in it the IP address of your server \n \n ENJOY !!'

	#Error
	cancel='You canceled the procedure, you do not agree that EMODYZ performs the installation automatically ...'
	notimpl='has not been implemented yet, be patient :)'
fi

sleep 3
echo -e '${a}'
sleep 5
echo -e '${b}'

function version { echo "$@" | gawk -F. '{ printf("%03d%03d%03d\n", $1,$2,$3); }'; }

if [[ "$OSTYPE" == "linux-gnu" ]]; then
        os='linux'
	if [[ $(lsb_release -is) = 'Debian' ]]; then
		outh=9.0
		ost=$(lsb_release -is)
		auth=1
		if [[ '$(version '$outh')' <  '$(version '$(lsb_release --release | awk '{ print $2 }')')' ]]; then
			vers=$(lsb_release --release | awk '{ print $2 }')
                        echo -e '\n \e[92mYour OS Has Authorized to proceed'
                        auth=1
                        echo -e '\n ************************* \n Informations Trouvée : \n *************************'
                        echo -e '\n Type de Distribution : ${os}'
                        echo -e '\n Nom de L OS : ${ost}'
                        echo -e '\n Version : ${vers}'
                        echo -e '\n Autorisé à installer ? OUI'

			startdebian9x=${1:-"st19x"}
			finishdebian9x=${1:-"finishdebian9x"}

			if [[ $os == 'linux' || $auth == 1 ]]; then
				echo -e '\n \e[39mPlease Confirm to accept auto Install ?'
				if [[ $lang == 'fr' ]]; then
					if [[ "non" == $(ask_y_or_n "Are you sure?") ]]; then
						echo -e '\n \e[39m ${confirm}'
						sleep 2
						if [[ "non" == $(ask_y_or_n "Are you *really* sure?") ]]; then
    							echo -e '\n \e[91m ${cancel}'
    							exit 0
						else
							echo -e '\n \e[39m ${installprog}'
							jumpto $startdebian9x
						fi
					else
						echo -e '\n \e[39m ${confirm}'
						sleep 2;
						if [[ "non" == $(ask_y_or_n "Are you *really* sure?") ]]; then
							echo -e '\n \e[91m ${cancel}'
    							exit 0
						else
							echo -e '\n \e[39m ${installprog}'
							jumpto $startdebian9x
						fi
					fi
				else
					if [[ "no" == $(ask_y_or_n "Are you sure?") ]]; then
						echo -e '\n \e[39m ${confirm}'
						sleep 2
						if [[ "no" == $(ask_y_or_n "Are you *really* sure?") ]]; then
    							echo -e '\n \e[91m ${cancel}'
    							exit 0
						else
							echo -e '\n \e[39m ${installprog}'
							jumpto $startdebian9x
						fi
					else
						echo -e '\n \e[39m ${confirm}'
						sleep 2
						if [[ "no" == $(ask_y_or_n "Are you *really* sure?") ]]; then
							echo -e '\n \e[91m ${cancel}'
    							exit 0
						else
							echo -e '\n \e[39m ${installprog}'
							jumpto $startdebian9x
						fi
					fi
				fi
			fi
		else
			vers='ufo'
		fi
	elif [[ $(lsb_release -is) = 'Ubuntu' ]]; then
		outh=16.00
		ost=$(lsb_release -is)
		auth=0
		if [[ '$(version '$outh')' <  '$(version '$(lsb_release --release | awk '{ print $2 }')')' ]]; then
			vers=$(lsb_release --release | awk '{ print $2 }')
			echo -e '\n \e[92mYour OS Has Authorized to proceed'
			auth=1
			echo -e '\n ************************* \n Informations Trouvée : \n *************************'
			echo -e '\n Type de Distribution : '$os' ...'
			echo -e '\n Nom de L OS : '$ost' ...'
			echo -e '\n Version : '$vers' ...'
			echo -e '\n Autorisé à installer ? OUI'

			startubuntu18x=${1:-"startubuntu18x"}

			if [[ $os == 'linux' || $auth == 1 ]]; then
				echo -e '\n \e[39mPlease Confirm to accept auto Install ?'
				if [[ "non" == $(ask_y_or_n "Are you sure?") ]]; then
					echo -e '\n \e[39m'$confirm
					sleep 2
					if [[ "non" == $(ask_y_or_n "Are you *really* sure?") ]]; then
    						echo -e '\n \e[91m'$cancel
    						exit 0
					else
						echo -e '\n \e[39m'$installprog
						jumpto $startubuntu18x
					fi
				else
					echo -e '\n \e[39m'$confirm
					sleep 2
					if [[ "non" == $(ask_y_or_n "Are you *really* sure?") ]]; then
						echo -e '\n \e[91m'$cancel
    						exit 0
					else
						echo -e '\n \e[39m'$installprog
						jumpto $startubuntu18x
					fi
				fi
			fi

			startubuntu18x:
			echo -e '\n \e[91m'$notimpl
			exit 0
		else
			vers=$(lsb_release --release | awk '{ print $2 }')
                        echo -e '\n \e[91mYour OS Has not Authorized to proceed'
			echo -e '\n \e[91mYour Version \e[39m'$vers' \e[91mRequired Version : \e[39m'$outh' \e[91mCheck if Update has Available on Github'
			auth=0
		fi
	else
		auth='unknow'
	fi
elif [[ "$OSTYPE" == "darwin" ]]; then
        os='MacOS'
	vers=$(lsb_release --release | awk '{ print $2 }')
        echo -e '\n \e[91mYour OS Has not Authorized to proceed'
        auth=0

elif [[ "$OSTYPE" == "cygwin" ]]; then
        os='Cygwin'
	vers=$(lsb_release --release | awk '{ print $2 }')
        echo -e '\n \e[91mYour OS Has not Authorized to proceed' 
        auth=0

elif [[ "$OSTYPE" == "msys" ]]; then
        os='lol'
	vers=$(lsb_release --release | awk '{ print $2 }')
        echo -e '\n \e[91mYour OS Has not Authorized to proceed' 
        auth=0

elif [[ "$OSTYPE" == "freebsd" ]]; then
        os='lool'
	vers=$(lsb_release --release | awk '{ print $2 }')
        echo -e '\n \e[91mYour OS Has not Authorized to proceed' 
        auth=0

else
        os='ufo'
	vers=$(lsb_release --release | awk '{ print $2 }')
        echo -e '\n \e[91mYour OS Has not Authorized to proceed' 
        auth=0

fi

echo -e $s

echo -e "\n \e[39m"$os
echo -e $ost
echo -e $auth
echo -e $vers
echo -e $res
echo -e $lang
