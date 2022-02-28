using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Mapping;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Queries.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrders,List<OrderResponse>>
    {
        private readonly IOrderReadRepository _repository;

        public GetAllOrdersHandler(IOrderReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
            var  orders = await _repository.GetAll();
            return orders.Select(order => order.DomainToResponse()).ToList()!;
        }
    }
}