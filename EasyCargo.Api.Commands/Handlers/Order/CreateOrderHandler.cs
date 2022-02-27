using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using EasyCargo.Api.Responses;
using MediatR;

namespace EasyCargo.Api.Handlers.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse?>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;


        public CreateOrderHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponse?> Handle(CreateOrderCommand req, CancellationToken cancellationToken)
        {
            CreateOrderRequest request = req._request;
            var order = _mapper.Map<Domains.Order>(request);
            var response = await _repository.CreateAsync(order);
            await _repository.SaveChangesAsync();
            return _mapper.Map<OrderResponse>(response);
        }
    }
}