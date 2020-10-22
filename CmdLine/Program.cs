using Autofac;
using Autofac.Extras.DynamicProxy;
using CmdLine.DataAccess;
using Shared.DataAccess;
using Shared.Domain;
using Shared.Repositories;
using Shared.Services;
using System;

namespace CmdLine
{
    static class Program
    {
        static void Main(string[] args)
        {
            ConfigureServices();

            using (var scope = Container.BeginLifetimeScope())
            {
                var templateService = scope.Resolve<ITemplateService>();
                Template retrieved = templateService.Create();

                Console.WriteLine($"{retrieved.Name}");
                
                // The following will throw LazyInitializationException as we applied the aspect to
                // the repository and not to the service. As a consquence we don't
                // have a session available here [Manfred]:
                Console.WriteLine($"{retrieved.Name} has {retrieved.Diagnoses.Count} diagnoses.");
            }
        }

        private static void ConfigureServices()
        {
            // This method is also called the "Composition Root" [Manfred]

            // Create your container builder.
            var containerBuilder = new ContainerBuilder();

            // Register repositories
            containerBuilder.RegisterType<TemplateRepository>()
                .As<ITemplateRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TransactionAspect))
                ;

            // Register services
            containerBuilder.RegisterType<TemplateService>()
                .As<ITemplateService>()
                ;

            // Others
            containerBuilder.RegisterType<SessionAccessor>()
                   .As<ISessionAccessor>()
                   ;

            var sessionFactory = Database.CreateSessionFactory(); // should be called once only [Manfred]
            containerBuilder.Register(_ => new TransactionAspect(sessionFactory));

            // Build the container:
            Container = containerBuilder.Build();
        }

        private static IContainer Container { get; set; }
    }
}
