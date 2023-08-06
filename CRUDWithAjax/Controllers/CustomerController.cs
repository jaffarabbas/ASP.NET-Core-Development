using DbLayer.Models;
using DbLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithAjax.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbMvcContext context;
        public CustomerController(DbMvcContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            List<Customer> customers = new CustomerDb(context).GetAll();
            return Json(customers);
        }

        public JsonResult Get(int id)
        {
            Customer customer = new CustomerDb(context).GetAllById(id);
            return Json(customer);
        }

        public JsonResult Remove(int id)
        {
            bool isRemoved = new CustomerDb(context).Remove(id);
            return Json(isRemoved);
        }

        public JsonResult Add(Customer customer)
        {
            int data = new CustomerDb(context).Add(customer);
            return Json(data);
        }
    }
}
