#!/bin/bash

fn_prompt_yn(){
	local prompt="$1"
	local initial="$2"

	if [ "${initial}" == "O" ]; then
		prompt+=" [O/n] "
	elif [ "${initial}" == "N" ]; then
		prompt+=" [o/N] "
	else
		prompt+=" [o/n] "
	fi

	while true; do
		read -e -i "${initial}" -p  "${prompt}" -r yn
		case "${on}" in
			[Oo]|[Oo][Uu][Ii]) return 0 ;;
			[Nn]|[Nn][Oo][Nn]|[Nn]) return 1 ;;
		*) echo "Merci de répondre Oui ou Non" ;;
		esac
	done
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
