using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scraps.Data;
using Scraps.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Scraps.API

{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;
        public CategoriesController(ApplicationDbContext db)
        {
            this._db = db;
        }


        // GET: api/values
        [HttpGet]
        public IList<Category> Get()
        {
            var categories = _db.Categories.ToList();
            return categories;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
