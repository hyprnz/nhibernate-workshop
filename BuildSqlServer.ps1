# Pull latest image
docker pull mcr.microsoft.com/mssql/server:2019-CU5-ubuntu-18.04

# Start SQL Server in docker container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=PassWord42" `
   -p 1433:1433 --name nhibernate-workshop `
   -d mcr.microsoft.com/mssql/server:2019-CU5-ubuntu-18.04
