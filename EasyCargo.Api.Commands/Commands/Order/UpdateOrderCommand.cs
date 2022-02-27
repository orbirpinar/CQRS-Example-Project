using System;
using EasyCargo.Api.Requests;
using MediatR;

namespace EasyCargo.Api.Commands.Order
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public UpdateOrderCommand(Guid id, UpdateOrderRequest request)
        {
            OrderId = id;
            OrderRequest = request;
        }

        public Guid OrderId { get; set; }
        public UpdateOrderRequest OrderRequest { get; set; }
    }
}