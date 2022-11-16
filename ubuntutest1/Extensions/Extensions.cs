using ubuntutest1.Dtos;
using ubuntutest1.Entities;

namespace ubuntutest1.Extensions
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}