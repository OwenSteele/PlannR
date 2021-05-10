using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlannR.App.Infrastructure;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlannR.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddClientInfrastructureServices();

            await builder.Build().RunAsync();
        }
    }
}
