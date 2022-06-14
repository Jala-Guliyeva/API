using API.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;

        }
       

        public IActionResult Get()
        {
            List<Product> products = _context.Products.ToList();
            return StatusCode(200, products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products
                 .FirstOrDefault(c => c.Id == id);
            if (product == null) return NotFound();

            return StatusCode(200, product);
        }

        [HttpPost("")]
        public IActionResult Create(Product product)
        {
            bool isExistName = _context.Products.Any
                (c => c.Name == product.Name);
            if (isExistName)
            {
                return BadRequest("Already exist");
            }

            Product newProduct = new Product();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            _context.SaveChanges();
            return StatusCode(200,newProduct);



        }
    }
}
