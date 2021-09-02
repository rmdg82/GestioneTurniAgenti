using Blazored.SessionStorage;
using Blazored.Toast;
using GestioneTurniAgenti.Client.Authentication;
using GestioneTurniAgenti.Client.AuthProviders;
using GestioneTurniAgenti.Client.HttpInterceptor;
using GestioneTurniAgenti.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace GestioneTurniAgenti.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("BaseAPI", (sp, cl) =>
             {
                 cl.BaseAddress = new Uri("https://localhost:5001/api/");
                 cl.EnableIntercept(sp);
             });

            builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("BaseAPI"));

            builder.Services.AddHttpClientInterceptor();
            builder.Services.AddScoped<HttpInterceptorService>();

            builder.Services.AddScoped<IAnagraficaService, AnagraficaService>();
            builder.Services.AddScoped<IEventiService, EventiService>();
            builder.Services.AddScoped<ITurniService, TurniService>();

            builder.Services.AddBlazoredToast();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, MockedAuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}