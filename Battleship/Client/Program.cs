using Battleship.Client.Services;
using Battleship.Game.Grids;
using Battleship.Game.Interfaces;
using Battleship.Game.Targeting;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Battleship.Client
{
    public class Program
    {
        private static async Task DebugDelayAsync()
        {
#if DEBUG
            await Task.Delay(5000);
#endif
        }

        public static async Task Main(string[] args)
        {
            await DebugDelayAsync();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IConfigService, ConfigService>();
            builder.Services.AddTransient<IGridCreator, GridCreator>();
            builder.Services.AddScoped<ITargetStrategy, RandomTargetStrategy>();
            builder.Services.AddScoped<IEngine, Engine>();
            await builder.Build().RunAsync();
        }
    }
}
