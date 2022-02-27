using System;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Queries.Order
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}