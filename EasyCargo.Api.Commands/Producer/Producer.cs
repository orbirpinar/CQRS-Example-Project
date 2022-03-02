using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using Shared.Model;

namespace EasyCargo.Api.Producer
{
    public class Producer: IProducer
    {
        private readonly IBus _bus;

        public Producer(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendAsync(OrderResponse orderResponse, CancellationToken cancellationToken)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:orderQueue"));
            await _bus.Send(endpoint, cancellationToken);
        }
    }
}