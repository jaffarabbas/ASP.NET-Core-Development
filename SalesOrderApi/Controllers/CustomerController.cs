using Microsoft.AspNetCore.Mvc;
using SalesOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Repository;

namespace SalesOrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository dBContext;
        public CustomerController(ICustomerRepository context)
        {
            dBContext = context;
        }

        [HttpGet("GetAll")]
        public async Task<List<CustomerEntity>> GetAll()
        {
            return await dBContext.GetAll();
        }
    }
}