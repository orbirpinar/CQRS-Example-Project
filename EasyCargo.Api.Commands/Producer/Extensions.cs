using System;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCargo.Api.Producer
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var uri = configuration.GetSection("RabbitMq:Uri").Value;
            var username = configuration.GetSection("RabbitMq:Username").Value;
            var password = configuration.GetSection("RabbitMq:Password").Value;
            services.AddMassTransit(x =>
            {
                x.AddBus(_ => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host(new Uri(uri), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                }));
            });
            services.AddMassTransitHostedService();
        }
    }
}