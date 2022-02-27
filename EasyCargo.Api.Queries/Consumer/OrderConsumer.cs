using System.Threading.Tasks;
using EasyCargo.Api.Queries.Mapping;
using EasyCargo.Api.Queries.Repositories.Interface;
using MassTransit;

using Shared.Model;

namespace EasyCargo.Api.Queries.Consumer
{
    public class OrderConsumer : IConsumer<OrderResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;


        public OrderConsumer(IOrderWriteRepository orderWriteRepository)
        { 
            _orderWriteRepository = orderWriteRepository;
        }

        public Task Consume(ConsumeContext<OrderResponse> context)
        {
            var orderResponse = context.Message;
            var order = orderResponse.ResponseToDomain();
            _orderWriteRepository.CreateAsync(order);
            return Task.CompletedTask;
        }
    }
}