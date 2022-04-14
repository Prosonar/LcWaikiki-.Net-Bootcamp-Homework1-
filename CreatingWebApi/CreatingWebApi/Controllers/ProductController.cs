using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                ProductName = "Telefon",
                Price = 5000,
                StockAmount = 250
            },
            new Product()
            {
                Id = 2,
                ProductName = "Tablet",
                Price = 2000,
                StockAmount = 100
            },
            new Product()
            {
                Id = 3,
                ProductName = "Saat",
                Price = 500,
                StockAmount = 200
            },
            new Product()
            {
                Id = 4,
                ProductName = "Bilgisayar",
                Price = 10000,
                StockAmount = 50
            },
            new Product()
            {
                Id = 5,
                ProductName = "Kulaklık",
                Price = 1000,
                StockAmount = 150
            },
        };

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = products.SingleOrDefault(x => x.Id == id);
            if(product == null)
            {
                return BadRequest("Ürün id bulunamadı.İşlem başarısız.");
            }
            return Ok(product);
        }
        
        [HttpGet("name/{name}")]
        public IActionResult GetProductsByName(string name)
        {
            List<Product> result = products.FindAll(x => x.ProductName.ToLower().Contains(name.ToLower()));
            if(result.Count == 0)
            {
                return Ok("Aranan isimde ürün bulunamadı."); 
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] Product product)
        {
            Product result = products.SingleOrDefault(x => x.Id == product.Id);
            if (result != null)
            {
                return BadRequest("Ürün id zaten mevcut. İşlem başarısız");
            }
            products.Add(product);
            return Ok("İşlem başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = products.SingleOrDefault(x => x.Id == id);
            if(product == null)
            {
                return BadRequest("Ürün id bulunamadı. İşlem başarısız");
            }
            products.Remove(product);
            return Ok("İşlem başarılı");
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromForm] Product product)
        {
            Product result = products.SingleOrDefault(x => x.Id == product.Id);
            if(result == null)
            {
                return BadRequest("Ürün id bulunamadı. İşlem başarısız.");
            }
            products.Find(x => x.Id == product.Id).ProductName = product.ProductName;
            products.Find(x => x.Id == product.Id).Price = product.Price;
            products.Find(x => x.Id == product.Id).StockAmount = product.StockAmount;
            return Ok("İşlem başarılı");
        }

    }
}
