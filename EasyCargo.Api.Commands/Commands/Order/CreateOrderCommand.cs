using EasyCargo.Api.Requests;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Commands.Order
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public CreateOrderCommand(CreateOrderRequest request)
        {
            _request = request;
        }

        public CreateOrderRequest _request { get; }
    }
}