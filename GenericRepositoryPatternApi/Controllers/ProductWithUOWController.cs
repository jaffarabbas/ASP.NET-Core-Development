﻿using GenericRepositoryPatternApi.Models;
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
                var productData = new Product()
                {
                    Name = product.Name,
                    Cid = product.Cid,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Image = product.Image,
                    CreatedOn = DateTime.Now
                };
                var repository = _unitOfWork.GetRepository<IProductRepository, Product>();
                var isproduct = repository.Post(productData);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAcync();
                return Ok(isproduct);
            }catch(Exception ex) {
                await _unitOfWork.RollBackAsync();
                throw;
            }
        }
    }
}
