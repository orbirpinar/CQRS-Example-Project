using System;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCargo.Api.Queries.Consumer
{
    public static class Extensions
    {
        public static void AddRabbitMq(this IServiceCollection services,IConfiguration configuration)
        {
            
            var uri = configuration.GetSection("RabbitMq:Uri").Value;
            var username = configuration.GetSection("RabbitMq:Username").Value;
            var password = configuration.GetSection("RabbitMq:Password").Value;
            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(CreateOrderConsumer).Assembly);
                x.AddConsumers(typeof(UpdateOrderConsumer).Assembly);
                x.AddConsumers(typeof(AttachProductConsumer).Assembly);
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(uri), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                    cfg.ReceiveEndpoint(QueeName.OrderCreated, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<CreateOrderConsumer>(provider);
                    });

                    cfg.ReceiveEndpoint(QueeName.OrderUpdated, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<UpdateOrderConsumer>(provider);
                    });

                    cfg.ReceiveEndpoint(QueeName.ProductAttached, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<AttachProductConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();
        }
    }
}