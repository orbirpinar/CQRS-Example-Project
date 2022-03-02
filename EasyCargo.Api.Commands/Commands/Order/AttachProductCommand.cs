using System;
using EasyCargo.Api.Requests;
using MediatR;

namespace EasyCargo.Api.Commands.Order
{
    public class AttachProductCommand: IRequest<Unit>
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