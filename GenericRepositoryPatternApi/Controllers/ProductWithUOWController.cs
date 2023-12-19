using GenericRepositoryPatternApi.Models;
using GenericRepositoryPatternApi.Repository.ProductRepository;
using GenericRepositoryPatternApi.Repository.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithUOWController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductWithUOWController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var repository = _unitOfWork.GetRepository<IProductRepository, Product>();
            var data = await repository.Get();
            return Ok(data);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            //var data = await _unitOfWork.ProductRepository.GetProductNameAsync(name);
            var repository = _unitOfWork.GetRepository<IProductRepository, Product>();
            var data = await repository.GetProductNameAsync(name);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            try
            {
                using var transaction = _unitOfWork.BeginTransaction();
                List<Models.Product> list = new List<Product> 
                {
                    new Product()
                    {
                        Name = product.Name,
                        Cid = product.Cid,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        Description = product.Description,
                        Image = product.Image,
                        CreatedOn = DateTime.Now
                    },
                    new Product()
                    {
                        Name = "asdasd",
                        Cid = 1,
                        Price = 0,
                        Quantity = 1,
                        Description = "asdasd",
                        Image = "sadasd",
                        CreatedOn = DateTime.Now
                    },
                };
               //var repository = _unitOfWork._ProductRepository.AddProduct(list);
                var repository = _unitOfWork.GetRepository<IProductRepository, Models.Product>();
                await repository.AddProduct(list);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAcync();
                return Ok(list);
            }catch(Exception ex) {
                await _unitOfWork.RollBackAsync();
                throw;
            }
        }
    }
}
