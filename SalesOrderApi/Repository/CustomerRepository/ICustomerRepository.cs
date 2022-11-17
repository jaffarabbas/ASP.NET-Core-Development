using SalesOrderApi.Models;

namespace SalesOrderApi.Repository
{
    public interface ICustomerRepository{
        Task<List<CustomerEntity>> GetAll(); 
    }
}