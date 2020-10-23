# Pull latest stable image
docker pull mcr.microsoft.com/mssql/server

# Start SQL Server in docker container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=PassWord42" `
   -p 1433:1433 --name nhibernate-workshop `
   -d mcr.microsoft.com/mssql/server

# Create new database
# Source for the retry logic:
# https://stackoverflow.com/a/47712807/411428
$attempts=20
$sleepInSeconds=3
do
{
    try
    {
        Invoke-Sqlcmd -ServerInstance "localhost,1433" -Username SA -Password PassWord42 -Query "CREATE DATABASE [nhibernate-workshop]";
        Write-Host "Database nhibernate-workshop created successfully."
        break;
    }
    catch [Exception]
    {
        #Write-Host $_.Exception.Message
        Write-Host "Retrying..."
    }            
    $attempts--
    if ($attempts -gt 0) { sleep $sleepInSeconds }
} while ($attempts -gt 0)
