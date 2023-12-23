using AutoMapper;
using GenericRepositoryPatternApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternApi.Repository.ProductRepository
{
    public class ProductRepository : Repository<Models.Product>, IProductRepository
    {
        public readonly DbJewelsiteContext _dbJewelsiteContext;
        public ProductRepository(DbJewelsiteContext dbJewelsiteContext) : base(dbJewelsiteContext)
        {
            _dbJewelsiteContext = dbJewelsiteContext;
        }

        public async Task<IEnumerable<Product>> GetProductNameAsync(string productName)
        {
            return await _dbSet.Where(p => p.Name == productName).ToListAsync();
        }

        public async Task<int> AddProduct(IEnumerable<Models.Product> products)
        {
            //_dbSet.AddRange(products);
            _dbJewelsiteContext.Products.AddRange(products);
            return 1;
        }
    }
}
