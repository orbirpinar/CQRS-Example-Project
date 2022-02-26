using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,OrderResponse?>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;


        public CreateOrderHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponse?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            CreateOrderRequest model = request._model;
            var order = _mapper.Map<Order>(model);
            var response = await _repository.CreateAsync(order);
            await _repository.SaveChangesAsync();
            return _mapper.Map<OrderResponse>(response);
        }
    }
}