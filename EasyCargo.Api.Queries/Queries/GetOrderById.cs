using System;
using EasyCargo.Api.Queries.Responses;
using MediatR;

namespace EasyCargo.Api.Queries.Queries
{
    public class GetOrderById: IRequest<OrderResponse>
    {
        public string Id { get; set; }

        public GetOrderById(string id)
        {
            Id = id;
        }
        
    }
}