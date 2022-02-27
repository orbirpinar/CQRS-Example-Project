using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using EasyCargo.Api.Queries.Responses;
using MediatR;

namespace EasyCargo.Api.Queries.Handlers
{
    public class GetOrderByIdHandler: IRequestHandler<GetOrderById,OrderResponse>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrderReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetById(request.Id);
            var response = _mapper.Map<OrderResponse>(order);
            return response;
        }
    }
}