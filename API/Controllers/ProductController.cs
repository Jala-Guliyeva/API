using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
                Product p=products
        }
    }
}
