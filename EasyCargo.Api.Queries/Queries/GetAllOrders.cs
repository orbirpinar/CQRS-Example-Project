using System.Collections.Generic;
using EasyCargo.Api.Queries.Responses;
using MediatR;

namespace EasyCargo.Api.Queries.Queries
{
    public class GetAllOrders: IRequest<List<OrderResponse>>
    {
    }
}