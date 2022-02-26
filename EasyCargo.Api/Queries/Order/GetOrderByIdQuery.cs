using System;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Queries
{
    public class GetOrderByIdQuery: IRequest<OrderResponse>
    {
        public Guid Id { get; }
        
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}