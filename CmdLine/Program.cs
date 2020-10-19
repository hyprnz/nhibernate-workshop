using Autofac;
using Autofac.Extras.DynamicProxy;
using CmdLine.DataAccess;
using Shared.DataAccess;
using Shared.Domain;
using Shared.Repositories;
using System;

namespace CmdLine
{
    static class Program
    {
        static void Main(string[] args)
        {
            Database.RunMigrations(); // Cheap operation if all migrations have already been applied [Manfred]

            ConfigureServices();

            using (var scope = Container.BeginLifetimeScope())
            {
                var templateRepository = scope.Resolve<ITemplateRepository>();
                Template retrieved = DoSomethingWithRepository(templateRepository);
                Console.WriteLine($"{retrieved.Name}");
            }
        }

        private static Template DoSomethingWithRepository(ITemplateRepository templateRepository)
        {
            var template = new Template() { Name = "Template42" };
            var diagnosis1 = new Diagnosis() { Name = "Diagnosis1", Template = template };
            template.Diagnoses.Add(diagnosis1);
            var objectId = templateRepository.Save(template);
            return templateRepository.GetById(objectId);
        }

        private static void ConfigureServices()
        {
            // This method is also called the "Composition Root" [Manfred]

            // Create your container builder.
            var containerBuilder = new ContainerBuilder();

            // Usually you're only interested in exposing the type via its interface:
            containerBuilder.RegisterType<TemplateRepository>()
                   .As<ITemplateRepository>()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(TransactionInterceptor))
                   ;
            containerBuilder.RegisterType<SessionAccessor>()
                   .As<ISessionAccessor>()
                   ;

            var sessionFactory = Database.CreateSessionFactory(); // should be called once only [Manfred]
            containerBuilder.Register(_ => new TransactionInterceptor(sessionFactory));

            // Build the container:
            Container = containerBuilder.Build();
        }

        private static IContainer Container { get; set; }
    }
}
