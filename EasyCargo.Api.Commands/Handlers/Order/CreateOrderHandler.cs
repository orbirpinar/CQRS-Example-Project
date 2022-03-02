using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using MassTransit;
using MediatR;
using OrderResponse = Shared.Model.OrderResponse;

namespace EasyCargo.Api.Handlers.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse?>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;
        private readonly IProducer _producer;


        public CreateOrderHandler(IOrderRepository repository, IMapper mapper, IProducer producer)
        {
            _repository = repository;
            _mapper = mapper;
            _producer = producer;
        }

        public async Task<OrderResponse?> Handle(CreateOrderCommand req, CancellationToken cancellationToken)
        {
            CreateOrderRequest request = req._request;
            var order = _mapper.Map<Domains.Order>(request);
            var response = await _repository.CreateAsync(order);
            await _repository.SaveChangesAsync();
            var orderResponse =  _mapper.Map<OrderResponse>(response);
            await _producer.SendAsync(orderResponse, cancellationToken);
            return orderResponse;
        }


    }
}