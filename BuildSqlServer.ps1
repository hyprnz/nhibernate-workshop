# Pull latest image
#docker pull mcr.microsoft.com/mssql/server:2019-CU5-ubuntu-18.04
docker pull mcr.microsoft.com/mssql/server

# Start SQL Server in docker container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=PassWord42" `
   -p 1433:1433 --name nhibernate-workshop `
   -d mcr.microsoft.com/mssql/server:2019-CU5-ubuntu-18.04

# Wait for SQL server....
Start-Sleep -Seconds 5

Invoke-Sqlcmd -HostName localhost -Username SA -Password PassWord42 -Query "CREATE DATABASE [nhibernate-workshop]"
