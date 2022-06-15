using FirstWebAPIProject.Entities;

namespace FirstWebAPIProject.repostries
{
    public class InMemItemRepositry{
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
    }
}