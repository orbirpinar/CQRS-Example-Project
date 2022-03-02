using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Domains;

namespace EasyCargo.Api.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<Order?> CreateAsync(Order order);

        Task<bool> UpdateAsync(Order order, Guid id);

        Task<bool> DeleteAsync(Guid id);

        Task SaveChangesAsync();
    }
}