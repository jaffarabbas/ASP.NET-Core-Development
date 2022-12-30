using JWT_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly JwtAuthentictionContext _context;
        public CustomerController(JwtAuthentictionContext context) {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<TblCustomer> GetAll()
        {
            return this._context.TblCustomers.ToList();
        }
    }
}
