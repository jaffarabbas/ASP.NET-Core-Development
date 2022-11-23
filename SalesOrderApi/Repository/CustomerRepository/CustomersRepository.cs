using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

namespace SalesOrderApi.Repository{
    public class CustomerRespository : ICustomerRepository{
        private readonly Sales_DBContext _dBContext;
        private readonly IMapper mapper;
        public CustomerRespository(Sales_DBContext context,IMapper mapper)
        {
            this._dBContext = context;
            this.mapper = mapper;
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            var customerData = await this._dBContext.TblCustomers.ToListAsync();
            if(customerData != null && customerData.Count > 0){
                return this.mapper.Map<List<TblCustomer>,List<CustomerEntity>>(customerData);
            }
            return new List<CustomerEntity>();
        }
    }
}