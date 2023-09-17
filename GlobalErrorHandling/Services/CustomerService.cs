using GlobalErrorHandling.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalErrorHandling.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly DbMvcContext _context;
        public CustomerService(DbMvcContext context)
        {
            _context = context;
        }
        public async Task<Customer> AddCustomers(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCustomers(int id)
        {
            var customer = await GetCustomersById(id);
            _context.Remove(customer);
            return customer != null ? true : false;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomersById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> UpdateCustomers(Customer customer)
        {
            var result = _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
