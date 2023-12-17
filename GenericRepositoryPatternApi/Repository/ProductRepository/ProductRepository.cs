using GenericRepositoryPatternApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternApi.Repository.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbJewelsiteContext dbJewelsiteContext) : base(dbJewelsiteContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductNameAsync(string productName)
        {
            return await _dbSet.Where(p => p.Name == productName).ToListAsync();
        }
    }
}
