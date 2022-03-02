using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Shared.Model;

namespace EasyCargo.Api.Producer
{
    public class ProductProducer: IProductProducer
    {
        private readonly IBus _bus;

        public ProductProducer(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendAsync(ConsumingProduct product, CancellationToken cancellationToken)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:productAttached"));
            await endpoint.Send(product, cancellationToken);
        }
    }
}