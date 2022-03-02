using System.Threading;
using System.Threading.Tasks;
using Shared.Model;

namespace EasyCargo.Api.Producer
{
    public interface IProducer
    {
        Task SendAsync(OrderResponse orderResponse,CancellationToken cancellationToken);
    }
}