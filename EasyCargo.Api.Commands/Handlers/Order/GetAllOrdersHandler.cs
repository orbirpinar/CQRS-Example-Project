using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Order;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Handlers.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public GetAllOrdersHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.FindAllAsync();
            return _mapper.Map<List<OrderResponse>>(orders);
        }
    }
}