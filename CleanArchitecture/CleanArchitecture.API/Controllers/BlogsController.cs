using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _blogService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var data = await _blogService.GetByIdAsync(id);
            if (data != null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            var data = await _blogService.CreateAsync(blog);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Blog blog)
        {
            var data = await _blogService.UpdateAsync(id,blog);
            if (data == 0)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var data = await _blogService.DeleteAsync(id);
            if (data == 0)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
