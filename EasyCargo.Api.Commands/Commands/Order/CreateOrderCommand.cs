using EasyCargo.Api.Requests;
using EasyCargo.Api.Responses;
using MediatR;

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