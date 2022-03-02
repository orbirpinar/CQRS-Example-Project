using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Interfaces;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Handlers.Order
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;
        private readonly IProducer _producer;


        public UpdateOrderHandler(IOrderRepository repository, IMapper mapper, IProducer producer)
        {
            _repository = repository;
            _mapper = mapper;
            _producer = producer;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domains.Order>(request.OrderRequest);
            var response = await _repository.UpdateAsync(order, request.OrderId);
            await _repository.SaveChangesAsync();
            
            var orderResponse = _mapper.Map<OrderResponse>(request.OrderRequest);
            orderResponse.Id = request.OrderId;
            await _producer.SendAsync(orderResponse,cancellationToken,EventName.OrderUpdated);
            
            return response;
        }
    }
}