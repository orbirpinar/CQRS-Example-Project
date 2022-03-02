using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Repositories.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Repositories.Implementation
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        private const string DatabaseName = "cargo";
        private const string CollectionName = "order";

        private readonly IMongoCollection<Order> _orderCollection;

        private readonly FilterDefinitionBuilder<Order> _builder = Builders<Order>.Filter;
        private readonly UpdateDefinitionBuilder<Order> _update = Builders<Order>.Update;


        public OrderWriteRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _orderCollection = database.GetCollection<Order>(CollectionName);
        }

        public async Task CreateAsync(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            var filter = _builder.Eq(existingOrder => existingOrder.Id, order.Id);
            var update = _update
                .Set(existingOrder => existingOrder.IsShipped, order.IsShipped)
                .Set(existingOrder => existingOrder.CargoKey, order.CargoKey)
                .Set(existingOrder => existingOrder.ShippingProvider, order.ShippingProvider);
            await _orderCollection.UpdateOneAsync(filter, update);
        }

        public async Task AttachProductAsync(Product product,Guid orderId)
        {
            var filter = _builder.Eq(existingOrder => existingOrder.Id, orderId);
            var update = _update.Push(x => x.Products, product);
            await _orderCollection.UpdateOneAsync(filter, update);
        }
    }
}