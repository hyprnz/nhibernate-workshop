using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using CmdLine.DataAccess;
using CmdLine.Domain;
using CmdLine.Repositories;
using FluentNHibernate.Conventions.Helpers.Prebuilt;
using NHibernate;
using System;

namespace CmdLine
{
    static class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Database.RunMigrations();

            ConfigureServices();

            using (var scope = Container.BeginLifetimeScope())
            {
                var templateRepository = scope.Resolve<ITemplateRepository>();
                var template = new Template() { Name = "Template42" };
                var diagnosis1 = new Diagnosis() { Name = "Diagnosis1", Template = template };
                template.Diagnoses.Add(diagnosis1);
                var objectId = templateRepository.Save(template);

                var retrieved = templateRepository.GetById(objectId);
                Console.WriteLine($"{retrieved.Name}");
            }
        }

        private static void ConfigureServices()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<TemplateRepository>().As<ITemplateRepository>().EnableInterfaceInterceptors();

            // Register TransactionInterceptor
            SessionFactory = Database.CreateSessionFactory(); // should be called only once
            builder.Register(_ => new TransactionInterceptor(SessionFactory));

            Container = builder.Build();
        }

        private static ISessionFactory SessionFactory { get; set; }
    }
}
