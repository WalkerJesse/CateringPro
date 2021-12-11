using AutoMapper;
using CateringPro.Application.Infrastructure;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Persistence.Persistence;
using CateringPro.WebApi.Infrastructure.Configuration;
using CateringPro.WebApi.Infrastructure.ModelBinding;
using CateringPro.WebApi.Services;
using CateringPro.WebApi.Services.Swagger;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

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
            services.AddApiControllers();
            services.AddApplicationServices();
            services.AddAutoMapperService();
            services.AddCors();
            services.AddFrameworkServices();
            services.AddPersistenceContext(this.Configuration);
            services.AddValidationBehaviourServices();
            services.AddSwaggerServices();
        }

        public void Configure(IApplicationBuilder app, IPersistenceContext persistenceContext, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catering Pro V1");
                    c.RoutePrefix = string.Empty;
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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

        #region - - - - - - IServiceCollectionExtension Methods - - - - - -

        public static void AddApiControllers(this IServiceCollection services)
            => services.AddControllers(options =>
            {
                options.ModelBinderProviders.Insert(0,
                    new BodyAndRouteModelBinderProvider(
                        options.ModelBinderProviders.OfType<BodyModelBinderProvider>().Single(),
                        options.ModelBinderProviders.OfType<ComplexTypeModelBinderProvider>().Single())
                        );
            }).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseInvoker, UseCaseInvoker>();

            services.Scan(s => s.FromAssemblies(GetAssemblies())
                    .AddClasses(classes => classes.AssignableTo(typeof(IBusinessRuleValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(GetAssemblies())
                    .AddClasses(classes => classes.AssignableTo(typeof(IUseCaseInteractor<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(GetAssemblies())
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }

        public static void AddAutoMapperService(this IServiceCollection services)
            => services.AddAutoMapper(GetAssemblies());

        public static void AddFrameworkServices(this IServiceCollection services)
            => services.AddScoped<ControllerAction>();

        public static void AddPersistenceContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IPersistenceContext, PersistenceContext>(options =>
            {
                var _DataStorageOptions = configuration.GetSection("DataStorageSettings").Get<DataStorageOptions>();
                options.UseSqlite(_DataStorageOptions.DatabaseConnectionString);
            });
        }

        public static void AddValidationBehaviourServices(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(GetAssemblies())
                    .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<RequestBodyFilter>();
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catering Pro", Version = "v1" });
            });
        }

        private static Assembly[] GetAssemblies()
            => new[] { Assembly.GetExecutingAssembly(), Application.Infrastructure.AssemblyUtility.GetAssembly(), CateringPro.Persistence.AssemblyUtility.GetAssembly() };


        #endregion IServiceCollectionExtension Methods

    }

}