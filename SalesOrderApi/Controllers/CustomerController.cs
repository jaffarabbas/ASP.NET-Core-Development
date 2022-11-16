using Microsoft.AspNetCore.Mvc;
using SalesOrderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesOrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Sales_DBContext dBContext;
        public CustomerController(Sales_DBContext context)
        {
            dBContext = context;
        }

        [HttpGet("GetAll")]
        public async Task<List<TblCustomer>> GetAll()
        {
            return await dBContext.TblCustomers.ToListAsync();
        }
    }
}