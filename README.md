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

## Technologies Used

* ASP.NET Core 3.1
* Fluent NHibernate
* Fluent Migrator
* Autofac

## Notes

* The code in this repository is not suitable for production purposes. It serves as an illustration only.
