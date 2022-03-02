using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Interfaces;
using MediatR;
using Shared.Model;

namespace EasyCargo.Api.Handlers.Order
{
    public class AttachProductHandler : IRequestHandler<AttachProductCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductProducer _productProducer;

        public AttachProductHandler(IProductRepository productRepository, IMapper mapper, IProductProducer productProducer)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productProducer = productProducer;
        }


        public async Task<Unit> Handle(AttachProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<Product>(request.ProductRequest); 
            var product = await _productRepository.AttachAsync(request.OrderId, productRequest);
            
            var consumingProduct = _mapper.Map<ConsumingProduct>(product);
            consumingProduct.OrderId = request.OrderId;
            await _productProducer.SendAsync(consumingProduct, cancellationToken);
            
            return Unit.Value;
        }
    }
}