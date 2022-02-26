using System;
using EasyCargo.Api.Requests;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Commands.Order
{
    public class CreateOrderCommand: IRequest<OrderResponse>
    {
        public CreateOrderRequest _model { get; }

        public CreateOrderCommand(CreateOrderRequest model)
        {
            _model = model;
        }
    }
}