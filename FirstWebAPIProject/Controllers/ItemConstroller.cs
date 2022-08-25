using FirstWebAPIProject.Dtos;
using FirstWebAPIProject.Entities;
using FirstWebAPIProject.Extension;
using FirstWebAPIProject.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPIProject.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase{
        private readonly IItemRepositry _itemRepository;

        public ItemController(IItemRepositry repositry){
            this._itemRepository = repositry;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(){
            var item = (await _itemRepository.GetItemsAsync()).Select(item => item.ExItemDto());
            return item;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemsAsync(Guid id){
            var item = await _itemRepository.GetItemAsync(id);
            if(item is null){
                return NotFound();
            }
            return item.ExItemDto();
        }
        

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemsDto createItemsDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = createItemsDto.Name,
                Price = createItemsDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
            await _itemRepository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemsAsync),new {id = item.Id}, item.ExItemDto());
        }

        [HttpPut("{id}")]
         public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemsDto updateItemDto) {
            var existingItem = await _itemRepository.GetItemAsync(id);
            if(existingItem is null){
                return NotFound(); 
            }
            Item updatedItem = existingItem with {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };
            await _itemRepository.UpdateItemAsync(updatedItem);
            return NoContent();
         }
    }
}