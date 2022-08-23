using FirstWebAPIProject.Dtos;
using FirstWebAPIProject.Entities;
using FirstWebAPIProject.Extension;
using FirstWebAPIProject.Repositries;
using FirstWebAPIProject.repostries;
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
        public IEnumerable<ItemDto> GetItems(){
            var item = _itemRepository.GetItems().Select(item => item.ExItemDto());
            return item;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItems(Guid id){
            var item = _itemRepository.GetItem(id);
            if(item is null){
                return NotFound();
            }
            return item.ExItemDto();
        }
        

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemsDto createItemsDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = createItemsDto.Name,
                Price = createItemsDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
            _itemRepository.CreateItem(item);
            return CreatedAtAction(nameof(GetItems),new {id = item.Id}, item.ExItemDto());
        }

        [HttpPut("{id}")]
         public ActionResult UpdateItem(Guid id, UpdateItemsDto updateItemDto) {
            var existingItem = _itemRepository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            Item updatedItem = existingItem with {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };
            _itemRepository.UpdateItem(updatedItem);
            return NoContent();
         }
    }
}