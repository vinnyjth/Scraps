using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scraps.Data;
using Microsoft.EntityFrameworkCore;
using Scraps.Models;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Scraps.API
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _db.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                Category = new Category { Id = p.Category.Id, Name = p.Category.Name },
                Quantity = p.Quantity,
                Price = p.Price,
                Sku = p.Sku,
                LotNumber = p.LotNumber,
                ProductionCost = p.ProductionCost
            }).ToList();
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            if (product.Id == 0)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
            }
            else
            {
                var original = _db.Products.FirstOrDefault(p => p.Id == product.Id);
                original.Name = product.Name;
                original.Type = product.Type;
                original.Category = product.Category;
                original.Quantity = product.Quantity;
                original.Sku = product.Sku;
                original.LotNumber = product.LotNumber;
                original.Price = product.Price;
                original.ProductionCost = product.ProductionCost;
                _db.SaveChanges();
            }
            return Ok(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("calculateProfit")]
        public IEnumerable<Product> CalculateProfit()
        {
            var products = _db.Products.ToList();
            foreach (var p in products)
            {
                p.TotalProfit = p.CalculateProfit();
            }
            return products;
        }

        [HttpGet("calculateOnHand")]
        public IEnumerable<Product> CalculateOnHand()
        {
            var products = _db.Products.ToList();
            foreach (var p in products)
            {
                p.TotalOnHand = p.CalculateOnHand();
            }
            return products;
        }
    }
}

