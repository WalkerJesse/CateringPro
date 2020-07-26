using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Infrastructure.Persistence;
using CateringPro.WebApi.Infrastructure.Configuration;
using CateringPro.WebApi.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CateringPro.WebApi
{

    public class Startup
    {

        #region - - - - - - Constructors - - - - - -

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public IConfiguration Configuration { get; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public void ConfigureServices(IServiceCollection services)
        {
            //this.ConfigureAppContextSettings(services);

            //services.AddAuthenticationServices();
            services.AddAutoMapperService();
            services.AddControllers();
            services.AddPersistenceContext(this.Configuration);
            services.AddRequestValidationBehaviourServices();
            services.AddServices();
            services.AddSwaggerServices();
        }

        public void Configure(IApplicationBuilder app, IPersistenceContext persistenceContext, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OSCAPI V1");
                    c.RoutePrefix = string.Empty;
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var _PersistenceContext = (PersistenceContext)persistenceContext;
            _PersistenceContext.Database.Migrate();
        }

        #endregion Methods

        #region - - - - - - Service Registration - - - - - -

        //private void ConfigureAppContextSettings(IServiceCollection services)
        //{
        //    services.Configure<DataStorageOptions>(this.Configuration.GetSection("DataStorageSettings"));
        //}

        #endregion Service Registration

    }

    internal static class IServiceCollectionExtensions
    {

        //public static void AddAuthenticationServices(this IServiceCollection services)
        //{
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = "Basic";
        //        options.DefaultChallengeScheme = "Basic";
        //    })
        //    .AddScheme<BasicAuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", opts => { });

        //    services.AddScoped<IAuthorisationHeaderParser, AuthorisationHeaderParser>();
        //    services.AddScoped<IAuthorisationHeaderProvider, AuthorisationHeaderProvider>();
        //}

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ControllerAction>();

            services.Scan(s => s.FromAssemblies(GetAssemblies())
                                .AddClasses()
                                .AsImplementedInterfaces()
                                .WithScopedLifetime());
        }

        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(GetAssemblies());
        }

        public static void AddPersistenceContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IPersistenceContext, PersistenceContext>(options =>
            {
                var _DataStorageOptions = configuration.GetSection("DataStorageSettings").Get<DataStorageOptions>();
                options.UseSqlite(_DataStorageOptions.DatabaseConnectionString);
            });
        }

        public static void AddRequestValidationBehaviourServices(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblies(GetAssemblies())
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "OSCAPI", Version = "v1" });
            });
        }

        private static Assembly[] GetAssemblies()
            => new[] { Assembly.GetExecutingAssembly(), Application.Infrastructure.AssemblyUtility.GetAssembly(), CateringPro.Infrastructure.AssemblyUtility.GetAssembly(), Presentation.AssemblyUtility.GetAssembly() };

    }

}