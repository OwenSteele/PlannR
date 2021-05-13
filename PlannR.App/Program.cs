using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlannR.App.Infrastructure;
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

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
