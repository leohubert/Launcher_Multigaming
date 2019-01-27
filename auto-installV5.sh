#!/bin/bash -xv

if [ -f ".dev-debug" ]; then
	exec 5>dev-debug.log
	BASH_XTRACEFD="5"
	set -x
fi

lang=$(locale | grep LANG | cut -d= -f2 | cut -d_ -f1)

version="190106"
shortname="core"
gameservername="core"
rootdir="$(dirname "$(readlink -f "${BASH_SOURCE[0]}")")"
selfname="$(basename "$(readlink -f "${BASH_SOURCE[0]}")")"
servicename="${selfname}"
autoinstalldir="${rootdir}/emodyz"
logdir="${rootdir}/log"
emodyzldir="${logdir}/emodyz"
functionsdir="${emodyzldir}/functions"
libdir="${emodyzldir}/lib"
tmpdir="${emodyzldir}/tmp"
userinput="${1}"

## GITHUB INFO
guser='MrDarkSkil'
grepo='Launcher_Multigaming'
gbranch='bash-unix'

core_functions.sh(){
	functionfile="${FUNCNAME}"
	fn_bootstrap_fetch_file_github "bash/functions" "core_functions.sh" "${functionsdir}" "chmodx" "run" "noforcedl" "nomd5"
}

fn_bootstrap_fetch_file(){
	remote_fileurl="${1}"
	local_filedir="${2}"
	local_filename="${3}"
	chmodx="${4:-0}"
	run="${5:-0}"
	forcedl="${6:-0}"
	md5="${7:-0}"
	# download file if missing or download forced
	if [ ! -f "${local_filedir}/${local_filename}" ]||[ "${forcedl}" == "forcedl" ]; then
		if [ ! -d "${local_filedir}" ]; then
			mkdir -p "${local_filedir}"
		fi
		# Defines curl path
		curlpath=$(command -v curl 2>/dev/null)

		# If curl exists download file
		if [ "$(basename "${curlpath}")" == "curl" ]; then
			# trap to remove part downloaded files
			echo -en "    fetching ${local_filename}...\c"
			curlcmd=$(${curlpath} -s --fail -L -o "${local_filedir}/${local_filename}" "${remote_fileurl}" 2>&1)
			local exitcode=$?
			if [ ${exitcode} -ne 0 ]; then
				echo -e "FAIL"
				if [ -f "${lemodyz}" ]; then
					echo -e "${remote_fileurl}" | tee -a "${lemodyz}"
					echo "${curlcmd}" | tee -a "${lemodyz}"
				fi
				exit 1
			else
				echo -e "OK"
			fi
		else
			echo "[ FAIL ] Curl is not installed"
			exit 1
		fi
		# make file chmodx if chmodx is set
		if [ "${chmodx}" == "chmodx" ]; then
			chmod +x "${local_filedir}/${local_filename}"
		fi
	fi

	if [ -f "${local_filedir}/${local_filename}" ]; then
		# run file if run is set
		if [ "${run}" == "run" ]; then
			source "${local_filedir}/${local_filename}"
		fi
	fi
}

fn_bootstrap_fetch_file_github(){
	github_file_url_dir="${1}"
	github_file_url_name="${2}"
	githuburl="https://raw.githubusercontent.com/${guser}/${grepo}/${gbranch}/${github_file_url_dir}/${github_file_url_name}"

	remote_fileurl="${githuburl}"
	local_filedir="${3}"
	local_filename="${github_file_url_name}"
	chmodx="${4:-0}"
	run="${5:-0}"
	forcedl="${6:-0}"
	md5="${7:-0}"
	# Passes vars to the file download function
	fn_bootstrap_fetch_file "${remote_fileurl}" "${local_filedir}" "${local_filename}" "${chmodx}" "${run}" "${forcedl}" "${md5}"
}

fn_print_center() {
	columns="$(tput cols)"
	line="$@"
	printf "%*s\n" $(( (${#line} + columns) / 2)) "${line}"
}

fn_print_horizontal(){
	char="${1:-=}"
	printf '%*s\n' "${COLUMNS:-$(tput cols)}" '' | tr ' ' "${char}"
}

fn_install_menu_bash() {
	local resultvar=$1
	title=$2
	caption=$3
	options=$4
	fn_print_horizontal
	fn_print_center "${title}"
	fn_print_center "${caption}"
	fn_print_horizontal
	menu_options=()
	while read -r line || [[ -n "${line}" ]]; do
		var=$(echo "${line}" | awk -F "," '{print $2 " - " $3}')
		menu_options+=( "${var}" )
	done <  ${options}
	menu_options+=( "Cancel" )
	select option in "${menu_options[@]}"; do
		if [ -n "${option}" ] && [ "${option}" != "Cancel" ]; then
			eval "$resultvar=\"${option/%\ */}\""
		fi
		break
	done
}

fn_install_menu_whiptail() {
	local menucmd=$1
	local resultvar=$2
	title=$3
	caption=$4
	options=$5
	height=${6:-40}
	width=${7:-80}
	menuheight=${8:-30}
	IFS=","
	menu_options=()
	while read -r line; do
		key=$(echo "${line}" | awk -F "," '{print $3}')
		val=$(echo "${line}" | awk -F "," '{print $2}')
		#menu_options+=( ${val//\'} '${key//\'}' )
	done < '${options}'
	OPTION=$(${menucmd} --title "${title}" --menu "${caption}" "${height}" "${width}" "${menuheight}" "${menu_options[@]}" 3>&1 1>&2 2>&3)
	if [ $? == 0 ]; then
		eval "$resultvar=\"${OPTION}\""
	else
		eval "$resultvar="
	fi
}

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

	cancel='Vous avez annulé la procédure, vous n avez pas acceptez que EMODYZ effectue l installation automatiquement...'
	confirm='Merci de confirmer votre choix'
	installprog='Merci d avoir accepter, nous effectuons l installation \n soyez patient :) \n \n \e[95mL equipe EMODYZ'
	a=' \n  \e[95mBienvenu(e) sur le script auto-install de la V5 \n \e[97mnous vous demanderons de choisir certaines option \n qui nous permet ainsi de determiner les meilleurs paramètres pour vous. \n .. \n \e[91mSoyez le plus attentif possible et consencieux dans vos réponse ...'
	b=' \n \e[95mEmodyz vérifie votre OS et votre configuration, veuillez patienté ...'
	checkdep='Nous vérifions les dépendances ...'
	checkdist='Nous vérifions et mettons à jour votre distribution ..'
	notimpl='N a pas été implémenté pour le moment, soyez patient :)'
	donotforgetv='N oubliez pas de bien séléctionner la Version 5.7 puis OK !!!!'
	successinstall='Installation Finalisé avec Succès !'
	successinstalladress='Ouvrez un nouvel onglet dans votre navigateur \n \n Mettez-y l adresse IP de votre serveur \n \n ENJOY !!'
fi

if [[ $lang == 'en' ]]; then
	function ask_y_or_n() {
		read -p 'Request Emodyz Server ([Y]es or [N]o): '
		case $(echo $REPLY | tr '[A-Z]' '[a-z]') in
		y|Y|yes) echo 'yes';;
		*) echo 'no';;
		esac
	}

	cancel='Skipped'
	confirm='Merci de confirmer votre choix'
	installprog='Merci d avoir accepter, nous effectuons l installation \n soyez patient :) \n \n \e[95mL equipe EMODYZ'
	a=' \n  \e[95mBienvenu(e) sur le script auto-install de la V5 \n \e[97mnous vous demanderons de choisir certaines option \n qui nous permet ainsi de determiner les meilleurs paramètres pour vous. \n .. \n \e[91mSoyez le plus attentif possible et consencieux dans vos réponse ...'
	b=' \n \e[95mEmodyz vérifie votre OS et votre configuration, veuillez patienté ...'
	checkdep='Nous vérifions les dépendances ...'
	checkdist='Nous vérifions et mettons à jour votre distribution ..'
	notimpl='N a pas été implémenté pour le moment, soyez patient :)'
	donotforgetv='N oubliez pas de bien séléctionner la Version 5.7 puis OK !!!!'
	successinstall='Installation Finalisé avec Succès !'
	successinstalladress='Ouvrez un nouvel onglet dans votre navigateur \n \n Mettez-y l adresse IP de votre serveur \n \n ENJOY !!'
fi

sleep 3
echo -e '${a}'
sleep 5
echo -e '${b}'
os=''
ost=''
vers=''
auth=''
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

			st19x:
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
			
			awk -i '/<Directory \/var\/www\/>/,/AllowOverride None/{sub("None", "All",$0)}{print}' /etc/apache2/apache2.conf | sudo tee /etc/apache2/apache2.conf > /dev/null
			sudo a2enmod rewrite
			sudo service apache2 restart
			sudo rm -rf /var/www/html
			cd /var/www && git clone https://github.com/MrDarkSkil/Launcher_Multigaming.git -b webpanel-test html
			chown -R www-data:www-data /var/www/html/games/
			chmod -R 777 /var/www/html/configs/
			jumpto $finishdebian9x

			finishdebian9x:
			echo -e '\n \e[92m'$successinstall
			echo -e '\n \e[92m'$successinstalladress
			exit 0;
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
