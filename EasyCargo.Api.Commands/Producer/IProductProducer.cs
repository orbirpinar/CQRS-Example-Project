using System.Threading;
using System.Threading.Tasks;
using Shared.Model;

namespace EasyCargo.Api.Producer
{
    public interface IProductProducer
    {
        Task SendAsync(ConsumingProduct product, CancellationToken cancellationToken);
    }
}