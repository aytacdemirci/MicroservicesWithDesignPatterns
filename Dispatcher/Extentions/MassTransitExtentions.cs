using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings;

namespace Dispatcher.Extentions
{
    public static class MassTransitExtentions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(cfg =>
            {
    

                cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    configure.Host(configuration.GetConnectionString("RabbitMQ"));
 
                }));
            });

            services.AddMassTransitHostedService();
        }
    }
}