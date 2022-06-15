using FirstWebAPIProject.Entities;
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
        public IEnumerable<Item> GetItems(){
            var item = _itemRepository.GetItems();
            return item;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItems(Guid id){
            var item = _itemRepository.GetItem(id);
            if(item is null){
                return NotFound();
            }
            return Ok(item);
        }
    }
}