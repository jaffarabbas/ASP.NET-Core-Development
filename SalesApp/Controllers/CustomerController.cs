using Microsoft.AspNetCore.Mvc;

namespace SalesApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
