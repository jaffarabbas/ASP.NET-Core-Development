using FirstWebAPIProject.Dtos;
using FirstWebAPIProject.Entities;

namespace FirstWebAPIProject.Extension{
    public static class Extensions{
        public static ItemDto ExItemDto(this Item item){
            return new ItemDto{
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }

    }
}