using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Domains;

namespace EasyCargo.Api.Queries.Repositories.Interface
{
    public interface IOrderReadRepository
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetById(string id);
    }
}