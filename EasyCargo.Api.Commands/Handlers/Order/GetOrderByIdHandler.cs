using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Order;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Handlers.Order
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse?>
    {
        private readonly IMapper _mapper;

        private readonly IOrderRepository _repository;

        public GetOrderByIdHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponse?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.FindByIdAsync(request.Id);
            return order == null ? null : _mapper.Map<OrderResponse>(order);
        }
    }
}