#!/bin/bash

#para executar de maneira assincrona é necessario utilizar a function, invoca-la posteriormente 'initialize_app_database' e no final o comando 'exec "$@"'
# function initialize_app_database() {
	# wait for SQL Server to come up
	echo importing data will start...
	sleep 15s
	echo executing script...
	
	# run the init script to create the DB and the tables in /table
	/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P @gerenciadorjogos123 -i ./scripts/deploy.sql
# }
# initialize_app_database &
# exec "$@"