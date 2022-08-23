using FirstWebAPIProject.Entities;
using FirstWebAPIProject.Repositries;

namespace FirstWebAPIProject.repostries
{
    public class InMemItemRepositry : IItemRepositry{
        private readonly List<Item> _items = new List<Item>(){
            new Item{
                Id = Guid.NewGuid(),
                Name = "Item 1",
                Price = 10.00m,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Item{
                Id = Guid.NewGuid(),
                Name = "Item 2",
                Price = 20.00m,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Item{
                Id = Guid.NewGuid(),
                Name = "Item 3",
                Price = 30.00m,
                CreatedDate = DateTimeOffset.UtcNow
            }
        };
        
        public IEnumerable<Item> GetItems(){
            return _items;
        }
        
        public Item GetItem(Guid id){
            return _items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
           var index = _items.FindIndex(items => items.Id == item.Id);
           _items[index] = item;
        }
    }
}