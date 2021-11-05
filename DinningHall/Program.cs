using DinningHall.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DinningHall
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<DinningHallServer, DinningHallServer>();
                    services.AddHostedService<Dinning>();
                }).Build().Run();
        }
    }
}