using MailService.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MailService.Extentions
{
    public static class MassTransitExtentions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                /*  x.AddConsumer<OrderCreatedConsumer>();

                  x.UsingRabbitMq((context, cfg) =>
                  {
                      cfg.Host(configuration.GetConnectionString("RabbitMQ"));

                      cfg.ReceiveEndpoint(RabbitMQSettingsConst.OrderCreatedEventQueueName, e =>
                      {
                          e.ConfigureConsumer<OrderCreatedConsumer>(context);
                      });
                  });*/
                x.AddConsumers(Assembly.GetExecutingAssembly()); //consumer'ları burada ekledik
                x.SetKebabCaseEndpointNameFormatter(); //MassTransit queue'ları nasıl oluştursun?
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMQ"));
                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();

         
        }
        }
}
