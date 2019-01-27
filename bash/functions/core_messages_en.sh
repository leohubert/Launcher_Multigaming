#!/bin/bash

fn_prompt_yn(){
	local prompt="$1"
	local initial="$2"

	if [ "${initial}" == "Y" ]; then
		prompt+=" [Y/n] "
	elif [ "${initial}" == "N" ]; then
		prompt+=" [y/N] "
	else
		prompt+=" [y/n] "
	fi

	while true; do
		read -e -i "${initial}" -p  "${prompt}" -r yn
		case "${yn}" in
			[Yy]|[Yy][Ee][Ss]) return 0 ;;
			[Nn]|[Nn][Oo]) return 1 ;;
		*) echo "Please answer yes or no." ;;
		esac
	done
}

cancel='You canceled the procedure, you do not agree that EMODYZ performs the installation automatically ...'
confirm='Please confirm your choice'
installprog='Thank you for accepting, we are doing the installation \n be patient :) \n \n \e[95mThe EMODYZ team'
a=' \n  \e[95mWelcome to the auto-install script of the V5 \n \e[97mwe will ask you to choose some option \n which allows us to determine the best parameters for you. \n .. \n \e[91mBe as attentive as possible and conscientious in your answers ...'
b=' \n \e[95mEmodyz checks your OS and your configuration, please wait ...'
checkdep='We check dependencies ...'
checkdist='We check and update your distribution ..'
notimpl='has not been implemented yet, be patient :)'
donotforgetv='Do not forget to select Version 5.7 and OK !!!!'
successinstall='Installation Finalized with Success !'
successinstalladress='Open a new tab in your browser \n \n Put in it the IP address of your server \n \n ENJOY !!'
