using GlobalErrorHandling.Models;
using System.Collections.Generic;

namespace GlobalErrorHandling.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer?> GetCustomersById(int id);
        public Task<Customer> AddCustomers(Customer customer);
        public Task<Customer> UpdateCustomers(Customer customer);
        public Task<bool> DeleteCustomers(int id);
    }
}
