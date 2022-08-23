using FirstWebAPIProject.Entities;
using MongoDB.Driver;

namespace FirstWebAPIProject.Repositries
{
    public class MongoDbItemRepository : IItemRepositry
    {
        private const string databaseName = "catalog";
        private const string collections = "items";
       
        private readonly IMongoCollection<Item> itemCollection;
        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemCollection = database.GetCollection<Item>(collections);
        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}