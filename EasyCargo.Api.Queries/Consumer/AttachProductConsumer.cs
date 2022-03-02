using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Repositories.Interface;
using MassTransit;
using Shared.Model;

namespace EasyCargo.Api.Queries.Consumer
{
    public class AttachProductConsumer: IConsumer<ConsumingProduct>
    {

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMapper _mapper;

        public AttachProductConsumer(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ConsumingProduct> context)
        {
            ConsumingProduct consumingProduct = context.Message;
            var product = _mapper.Map<Product>(consumingProduct);
            await _orderWriteRepository.AttachProductAsync(product,consumingProduct.OrderId);
        }
    }
}