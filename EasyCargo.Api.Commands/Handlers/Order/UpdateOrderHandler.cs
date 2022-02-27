using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Repositories.Interfaces;
using MediatR;

namespace EasyCargo.Api.Handlers.Order
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;


        public UpdateOrderHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domains.Order>(request.OrderRequest);
            var response = _repository.UpdateAsync(order, request.OrderId);
            _repository.SaveChangesAsync();
            return response;
        }
    }
}