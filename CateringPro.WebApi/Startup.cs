using CateringPro.Application.Infrastructure.Pipeline;
using CateringPro.Application.Services.Persistence;
using CateringPro.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CateringPro.WebApi
{

    public class Startup
    {

        #region - - - - - - Constructors - - - - - -

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public IConfiguration Configuration { get; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddPersistenceContext();
            services.AddMediatRAndPipelineBehaviour();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSwaggerServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "CPAPI v1");
                    s.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });
        }

        #endregion Methods

    }

    internal static class IServiceCollectionExtensions
    {

        #region - - - - - - Methods - - - - - -

        public static void AddPersistenceContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPersistenceContext), typeof(PersistenceContext));
        }

        public static void AddMediatRAndPipelineBehaviour(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessRuleValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            services.AddMediatR(
                Application.Infrastructure.AssemblyUtility.GetAssembly(),
                Presentation.AssemblyUtility.GetAssembly());
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "CPAPI", Version = "v1" });
            });
        }

        #endregion Methods

    }

}
