using Hepsiburada.MarsRover.Business.VehicleCommands;
using Hepsiburada.MarsRover.ConsoleApp.Processes;
using Hepsiburada.MarsRover.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hepsiburada.MarsRover.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MarsRoverService>();
                    services.AddSingleton<IPlateauProcess, PlateauProcess>();
                    services.AddTransient<IRoverProcess, RoverProcess>();
                    services.AddTransient<IVehicleMover, VehicleMover>();
                });
    }
}
