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
        private readonly IOrderProducer _orderProducer;


        public CreateOrderHandler(IOrderRepository repository, IMapper mapper, IOrderProducer orderProducer)
        {
            _repository = repository;
            _mapper = mapper;
            _orderProducer = orderProducer;
        }

        public async Task<OrderResponse?> Handle(CreateOrderCommand req, CancellationToken cancellationToken)
        {
            CreateOrderRequest request = req.Request;
            var order = _mapper.Map<Domains.Order>(request);
            var response = await _repository.CreateAsync(order);
            await _repository.SaveChangesAsync();
            var orderResponse =  _mapper.Map<OrderResponse>(response);
            await _orderProducer.SendAsync(orderResponse, cancellationToken,EventName.OrderCreated);
            return orderResponse;
        }


    }
}