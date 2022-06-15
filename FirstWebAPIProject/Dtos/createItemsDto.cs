using System.ComponentModel.DataAnnotations;

namespace FirstWebAPIProject.Dtos
{
    public record CreateItemsDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}