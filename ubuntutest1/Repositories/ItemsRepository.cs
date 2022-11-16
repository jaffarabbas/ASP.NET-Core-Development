using ubuntutest1.Dtos;
using ubuntutest1.Entities;

namespace ubuntutest1.Repsositories
{
    public interface ITemRepository{
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}