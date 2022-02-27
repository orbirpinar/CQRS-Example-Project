using System;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Queries.Queries
{
    public class GetOrderById: IRequest<OrderResponse>
    {
        public Guid Id { get; set; }

        public GetOrderById(Guid id)
        {
            Id = id;
        }
        
    }
}