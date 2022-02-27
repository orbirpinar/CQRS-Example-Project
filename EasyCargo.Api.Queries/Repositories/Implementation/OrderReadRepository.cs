using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Repositories.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Repositories.Implementation
{
    public class OrderReadRepository: IOrderReadRepository
    {

        private const string DatabaseName = "cargo";
        private const string CollectionName = "order";

        private readonly IMongoCollection<Order> _orderCollection;

        private readonly FilterDefinitionBuilder<Order> _builder = Builders<Order>.Filter;


        public OrderReadRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _orderCollection = database.GetCollection<Order>(CollectionName);
        }
        public async Task<List<Order>> GetAll()
        {
            return await _orderCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Order?> GetById(Guid id)
        {
            var filter = _builder.Eq(order => order.Id, id);
            return await _orderCollection.Find(filter).SingleOrDefaultAsync();
        }
    }
}