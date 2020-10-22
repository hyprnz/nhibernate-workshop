# NHibernate Workshop

The example code in this repository demonstrates one option for implementing transaction handling as a cross-cutting concern using an aspect.

Points of interest:

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
* Repository Pattern

## Prerequisites

* VS Code or Visual Studio 2019 Community Edition
* Docker Desktop
* Powershell 7

## Container With Sample Database

No need to install SQL Server. Instead this sample makes use of a Docker container with SQL Server pre-installed. Here is a set of scripts to make this a bit easier if you are not used to Docker Desktop.

To Do This | Use Script
-----------|-----------
Build the database container. This also creates the database. | BuildSqlServer.ps1
Start the database container | StartSqlServer.ps1
Stop the database container | StopSqlServer.ps1
Remove the database container. This also deletes the database. | RemoveSqlServer.ps1

## Technologies Used

* ASP.NET Core 3.1
* Fluent NHibernate
* Fluent Migrator
* Autofac

## Notes

* The code in this repository is not suitable for production purposes. It serves as an illustration only.
