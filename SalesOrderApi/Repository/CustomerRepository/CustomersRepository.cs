using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

namespace SalesOrderApi.Repository{
    public class CustomerRespository : ICustomerRepository{
        private readonly Sales_DBContext _dBContext;
        public CustomerRespository(Sales_DBContext context)
        {
            this._dBContext = context;
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            return await this._dBContext.TblCustomers.ToListAsync();
        }
    }
}