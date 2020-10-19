﻿using FluentMigrator.Runner;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System;

namespace Shared.DataAccess
{
    public class Database
    {
        public static void RunMigrations()
        {
            var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                RunMigrations(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SqlServer support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(ConnectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(Database).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        public static ISessionFactory CreateSessionFactory()
        {
            RunMigrations();

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString)
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Database>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.ForeignKey.EndsWith("Id")))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void RunMigrations(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }

        private const string ConnectionString = "Data Source=localhost;Initial Catalog=nhibernate-workshop;Persist Security Info=True;User ID=sa;Password=PassWord42;Pooling=False";
    }
}
