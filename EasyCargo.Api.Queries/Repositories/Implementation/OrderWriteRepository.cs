using System.Threading.Tasks;
using EasyCargo.Api.Queries.Repositories.Interface;
using MongoDB.Driver;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Repositories.Implementation
{
    public class OrderWriteRepository : IOrderWriteRepository
    {
        private const string DatabaseName = "cargo";
        private const string CollectionName = "order";

        private readonly IMongoCollection<Order> _orderCollection;

        private readonly FilterDefinitionBuilder<Order> _builder = Builders<Order>.Filter;


        public OrderWriteRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _orderCollection = database.GetCollection<Order>(CollectionName);
        }

        public async Task CreateAsync(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
        }
    }
}