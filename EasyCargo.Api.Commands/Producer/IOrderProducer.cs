using System.Threading;
using System.Threading.Tasks;
using Shared.Model;

namespace EasyCargo.Api.Producer
{
    public interface IOrderProducer
    {
        Task SendAsync(OrderResponse orderResponse,CancellationToken cancellationToken,string eventName);

    }
}