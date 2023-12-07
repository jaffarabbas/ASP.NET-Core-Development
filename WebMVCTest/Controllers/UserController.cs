using Microsoft.AspNetCore.Mvc;
using WebMVCTest.Models;

namespace WebMVCTest.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = new User()
            {
                id = id,
                user = "asdasd",
                email = "asda2@asda.com"
            };
            return View(data);
        }
    }
}
