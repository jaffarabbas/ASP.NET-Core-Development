using BookStoreApi.Models;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBookAsAsync()
        {
            var books = await _bookRepository.GetAllBookAsAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookFromIdAsAsync([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookFromIdAsAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBookAsAsync([FromBody]BookModel bookModel)
        {
            var id = await _bookRepository.AddBooksAsync(bookModel);
            return CreatedAtAction(nameof(GetBookFromIdAsAsync), new {id = id , controller = "book" },id);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsAsync([FromRoute] int id,[FromBody] BookModel bookModel)
        {
            await _bookRepository.UpdateBookFromIdAsAsync(id,bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatchAsAsync([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepository.UpdateBookFromPatchIdAsAsync(id, bookModel);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookByIdAsAsync([FromRoute] int id)
        {
            await _bookRepository.DeleteBooksAsync(id);
            return Ok();
        }
    }
}
 