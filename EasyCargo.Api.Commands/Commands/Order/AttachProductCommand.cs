using System;
using EasyCargo.Api.Requests;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Commands.Order
{
    public class AttachProductCommand: IRequest<OrderResponse>
    {

        public AttachProductCommand(Guid orderId,AttachProductRequest productRequest)
        {
            ProductRequest = productRequest;
            OrderId = orderId;
        }
        
        public Guid OrderId { get; }
        public AttachProductRequest ProductRequest { get; }
        
    }
}