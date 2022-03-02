using EasyCargo.Api.Requests;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Commands.Order
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public CreateOrderCommand(CreateOrderRequest request)
        {
            Request = request;
        }

        public CreateOrderRequest Request { get; }
    }
}