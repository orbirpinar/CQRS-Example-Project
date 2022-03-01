using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Repositories.Interface;
using MassTransit;

using Shared.Model;

namespace EasyCargo.Api.Queries.Consumer
{
    public class OrderConsumer : IConsumer<OrderResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMapper _mapper;


        public OrderConsumer(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public Task Consume(ConsumeContext<OrderResponse> context)
        {
            var orderResponse = context.Message;
            var order = _mapper.Map<Order>(orderResponse);
            _orderWriteRepository.CreateAsync(order);
            return Task.CompletedTask;
        }
    }
}