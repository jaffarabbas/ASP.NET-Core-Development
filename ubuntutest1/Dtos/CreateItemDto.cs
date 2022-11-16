using System.ComponentModel.DataAnnotations;

namespace ubuntutest1.Dtos
{
     public record CreateItemDto{
        [Required]
        public string Name { get; init; }
        [Required]
        public decimal Price{ get; init; }
    }
}