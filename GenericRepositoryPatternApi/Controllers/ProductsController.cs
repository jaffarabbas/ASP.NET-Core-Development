using GenericRepositoryPatternApi.Entity;
using GenericRepositoryPatternApi.Models;
using GenericRepositoryPatternApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Entity.Product> _repository;
        public ProductsController(IRepository<Entity.Product> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.Get();
            return Ok(products);
        }
    }
}
