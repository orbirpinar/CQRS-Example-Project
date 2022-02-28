using System.Collections.Generic;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Queries.Queries
{
    public class GetAllOrders: IRequest<List<OrderResponse>>
    {
    }
}