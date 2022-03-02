using System;
using System.Net.Mail;
using System.Threading.Tasks;
using EasyCargo.Api.Domains;

namespace EasyCargo.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> AttachAsync(Guid orderId, Product product);
        Task SaveChangesAsync();
    }
}