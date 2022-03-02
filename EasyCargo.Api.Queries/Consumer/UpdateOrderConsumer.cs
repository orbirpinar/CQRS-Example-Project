using System.Threading.Tasks;
using MassTransit;
using Shared.Model;

namespace EasyCargo.Api.Queries.Consumer
{
    public class UpdateOrderConsumer: IConsumer<OrderResponse>
    {
        public Task Consume(ConsumeContext<OrderResponse> context)
        {
            var orderResponse = context.Message;
            return Task.CompletedTask;
        }
    }
}