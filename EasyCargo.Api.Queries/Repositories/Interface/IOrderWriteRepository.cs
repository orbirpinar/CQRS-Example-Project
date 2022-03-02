using System;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Domains;
using Shared.Model;

namespace EasyCargo.Api.Queries.Repositories.Interface
{
    public interface IOrderWriteRepository
    {
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);

        Task AttachProductAsync(Product product, Guid orderId);
    }
}