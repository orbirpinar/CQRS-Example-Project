using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Implementations;
using EasyCargo.Api.Repositories.Interfaces;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Handlers.Order
{
    public class AttachProductHandler : IRequestHandler<AttachProductCommand,OrderResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProducer _producer;

        public AttachProductHandler(IProductRepository productRepository, IMapper mapper, IProducer producer)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _producer = producer;
        }


        public async Task<OrderResponse> Handle(AttachProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductRequest); 
            await _productRepository.AttachAsync(request.OrderId, product);
            await _productRepository.SaveChangesAsync();
            
            var orderResponse = _mapper.Map<OrderResponse>(request.ProductRequest);
            await _producer.SendAsync(orderResponse, cancellationToken, EventName.ProductAttached);
            return orderResponse;
        }
    }
}