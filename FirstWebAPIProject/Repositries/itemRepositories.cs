using FirstWebAPIProject.Entities;

namespace FirstWebAPIProject.Repositries{
    public interface IItemRepositry{
        public Task<Item> GetItemAsync(Guid id);
        public Task<IEnumerable<Item>> GetItemsAsync();
        public Task CreateItemAsync(Item item);
        public Task UpdateItemAsync(Item item);
        public Task DeleteItemAsync(Item item);
    }
}