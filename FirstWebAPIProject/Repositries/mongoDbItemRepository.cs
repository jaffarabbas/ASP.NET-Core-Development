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

        public async Task CreateItemAsync(Item item)
        {
            await itemCollection.InsertOneAsync(item);
        }


        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemCollection.ReplaceOneAsync(filter, item);
        }
        public async Task DeleteItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemCollection.DeleteOneAsync(filter);
        }
    }
}