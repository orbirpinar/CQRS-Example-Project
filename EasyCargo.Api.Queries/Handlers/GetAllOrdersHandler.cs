using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using EasyCargo.Api.Queries.Responses;
using MediatR;

namespace EasyCargo.Api.Queries.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrders,List<OrderResponse>>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(IOrderReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
            var  orders = await _repository.GetAll();
            return _mapper.Map<List<OrderResponse>>(orders);
        }
    }
}