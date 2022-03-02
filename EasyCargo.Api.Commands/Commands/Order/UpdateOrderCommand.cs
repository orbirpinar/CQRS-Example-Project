using System;
using EasyCargo.Api.Requests;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Commands.Order
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public UpdateOrderCommand(Guid id, UpdateOrderRequest request)
        {
            OrderId = id;
            OrderRequest = request;
        }

        public Guid OrderId { get; }
        public UpdateOrderRequest OrderRequest { get; }
    }
}