using FirstWebAPIProject.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FirstWebAPIProject.Repositries
{
    public class MongoDbItemRepository : IItemRepositry
    {
        private const string databaseName = "catalog";
        private const string collections = "items";
       
        private readonly IMongoCollection<Item> itemCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemCollection = database.GetCollection<Item>(collections);
        }

        public void CreateItem(Item item)
        {
            itemCollection.InsertOne(item);
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}