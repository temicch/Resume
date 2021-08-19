using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Resume.Application;
using Resume.Application.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resume
{
    public class Program
    {
        private const string PERSON_JSON_FILE_PATH = "person.json";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        protected static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var hostEnv = sp.GetRequiredService<IWebAssemblyHostEnvironment>();

                return new HttpClient
                {
                    BaseAddress = new Uri(hostEnv.BaseAddress)
                };
            });
            services.AddScoped<IPersonProvider>(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                return new PersonProvider(httpClient, PERSON_JSON_FILE_PATH);
            });
        }
    }
}