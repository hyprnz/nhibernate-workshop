# NHibernate Workshop

The example code in this repository demonstrates one option for implementing transaction handling as a cross-cutting concern using an aspect. It also shows how to use this in a console application and in a web API application (ASP.NET Core).

## Points of interest

* Dependency injection (DI)
* Inversion of Control (IoC)
* Autofac
  * Replacing default IoC containers
  * Interceptor as an aspect
* AsyncLocal versus ThreadLocal
* Controllers as services
* Intercepting a controller
* Dependency injection of
  * Service
  * Repository
  * Session Accessor
* Repository Pattern
* UpOnlyMigration

## Prerequisites

* One of the following IDEs:
  * VS Code
  * Visual Studio 2019 Community Edition
* Docker Desktop
* Powershell 7

## Container With Sample Database

No need to install SQL Server. Instead this sample makes use of a Docker container with SQL Server pre-installed. Here is a set of scripts to make this a bit easier if you are not used to Docker Desktop.

To Do This | Use Script
-----------|-----------
Build and start the container withe SQL Server instance. This also creates the database. | BuildSqlServer.ps1
Start the container with the SQL Server instance | StartSqlServer.ps1
Stop the container with the SQL Server instance | StopSqlServer.ps1
Remove the container with the SQL Server instance. This also deletes the database. | RemoveSqlServer.ps1

Note that when you run the script `BuildSqlServer.ps1` you may observe error messages. This happens when the container is running but the SQL Server instance is not quite ready to accept connections. The script will try for up to a minute. It should take a lot less than that. Duration is subject to the speed of your computer.

If you already have a SQL Server instance installed on your computer, please also consult the suggestion below to avoid network port conflicts.

## Technologies Used

* ASP.NET Core 3.1
* Fluent NHibernate
* Fluent Migrator
* Autofac

## Notes

* The code in this repository is not suitable for production purposes. It serves as an illustration for NHibernate related concepts only.

## Existing SQL Server Instance and Network Port 1433
SQL Server uses network port 1433 by default. Therefore if you already have instance of SQL Server installed on your computer, it is highly likely that you won't be able to start the docker container with the SQL Server instance using the script `BuildSqlServer.ps1`. The reason is that a port can be used by one application only.

To resolve this issue either stop the existing SQL Server instance on your computer or follow these steps:

1. In file `BuildSqlServer.ps1` change the paramter for `docker run` from `-p 1433:1433` to `-p xxxx:1433` where xxxx is the number of a port that is available on your computer. For example you could use `-p 1466:1433`.
2. In file `BuildSqlServer.ps1` replace `-ServerInstance "localhost,1433"` with `-ServerInstance "localhost,xxxx"` where xxxx is the port number you chose in the previous step
3. In class `Database` change the connection string by replacing `Server=localhost` with `Server=localhost,xxxx` where xxxx is the port number you chose in the first step.
