using System;
using ubuntutest1.Dtos;
using ubuntutest1.Entities;
using ubuntutest1.Repsositories;

namespace ubuntutest1.Repsositories
{
    public class InMemItemsRepository : ITemRepository{
        private readonly List<Item> items = new(){
            new Item{
                Id=Guid.NewGuid(),
                Name="jaffar",
                Price=99,
                CreatedDate=DateTimeOffset.UtcNow
            }
        };

        public IEnumerable<Item> GetItems(){
            return items;
        }

        public Item GetItem(Guid id){
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
    }
}