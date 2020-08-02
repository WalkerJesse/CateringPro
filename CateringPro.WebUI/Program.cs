using CateringPro.WebApi.Consumer;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CateringPro.WebUI
{

    public class Program
    {

        #region - - - - - - Methods - - - - - -

        public static async Task Main(string[] args)
        {
            var _Builder = WebAssemblyHostBuilder.CreateDefault(args);
            _Builder.RootComponents.Add<App>("app");

            _Builder.Services.AddScoped<IngredientsApi>();
            _Builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(_Builder.HostEnvironment.BaseAddress) });

            await _Builder.Build().RunAsync();
        }

        #endregion Methods

    }

}
