using System.Collections.Generic;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Queries
{
    public class GetAllOrdersQuery: IRequest<List<OrderResponse>>
    {
        
    }
}