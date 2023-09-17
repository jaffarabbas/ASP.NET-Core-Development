using GlobalErrorHandling.Exceptions;
using GlobalErrorHandling.Models;
using GlobalErrorHandling.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger,ICustomerService customerService)
        {
            this.logger = logger;
            this._customerService = customerService;
        }

        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> Get() 
        {
            var result = await _customerService.GetCustomers();
            return Ok(result);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> Add(Customer customer)
        {
            var result = await _customerService.AddCustomers(customer);
            return Ok(result);
        }

        [HttpGet("GetCustomerByID")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerService.GetCustomersById(id);
            return result != null ? Ok(result) : throw new NotFoundException("Id Not Found");
        }
    }
}
