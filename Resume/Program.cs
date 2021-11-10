using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Resume;
using Resume.Application;
using Resume.Application.Interfaces;

const string PERSON_JSON_FILE_PATH = "person.json";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

ConfigureServices(builder.Services);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services)
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
