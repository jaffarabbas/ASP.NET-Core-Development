using FirstWebAPIProject.Entities;

namespace FirstWebAPIProject.Repositries{
    public interface IItemRepositry{
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}