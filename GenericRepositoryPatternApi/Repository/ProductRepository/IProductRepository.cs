using GenericRepositoryPatternApi.Models;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Repository.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductNameAsync(string productName);
    }
}
