using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Repositories.Interface;
using MongoDB.Entities;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Repositories.Implementation
{
    public class OrderRepository: IOrderReadRepository
    {

        public async Task<List<Order>> GetAll()
        {
            return await DB.Find<Order>()
                .Match(_ => true)
                .ExecuteAsync();
        }

        public async Task<Order?> GetById(string id)
        {
           return await DB.Find<Order>()
                .Match(o => o.ID.Equals(id))
                .ExecuteSingleAsync();
        }
    }
}