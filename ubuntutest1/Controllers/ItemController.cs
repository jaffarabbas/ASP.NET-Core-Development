using Microsoft.AspNetCore.Mvc;
using ubuntutest1.Repsositories;
using ubuntutest1.Entities;
using ubuntutest1.Dtos;
using ubuntutest1.Extensions;

namespace ubuntutest1.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase{
        private readonly ITemRepository _repository;
        public ItemController(ITemRepository repository){
            this._repository = repository;
         }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){
            var items = _repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var items = _repository.GetItem(id);
            if(items is null){
                return NotFound();
            }
            return items.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto item){
            Item nitem = new(){
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
            _repository.CreateItem(nitem);
            return CreatedAtAction(nameof(GetItem),new { Id = nitem.Id}, nitem.AsDto());
        }
    }    
}