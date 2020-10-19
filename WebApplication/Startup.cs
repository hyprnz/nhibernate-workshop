using Autofac;
using Autofac.Extras.DynamicProxy;
using CmdLine.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.DataAccess;
using Shared.Repositories;
using WebApplication.Controllers;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Usually you're only interested in exposing the type via its interface:
            containerBuilder.RegisterType<TemplateRepository>()
                   .As<ITemplateRepository>()
                   ;
            containerBuilder.RegisterType<TemplateController>()
                   .EnableClassInterceptors()
                   .InterceptedBy(typeof(TransactionInterceptor))
                   ;
            containerBuilder.RegisterType<SessionAccessor>()
                   .As<ISessionAccessor>()
                   ;

            var sessionFactory = Database.CreateSessionFactory(); // should be called once only [Manfred]
            containerBuilder.Register(_ => new TransactionInterceptor(sessionFactory));
        }

        // Configuration Method Naming Conventions: more details at:
        // https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html#configuration-method-naming-conventions
    }
}
