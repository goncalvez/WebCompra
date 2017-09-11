using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAccountAPI.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAccountAPI.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        /// <summary>
        /// GET: api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Purchase> Get()
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Purchases.ToList();
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Purchase Get(Int64 id)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Purchases.Find(id);
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Post([FromBody]Purchase value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Purchases.Find(value.code) == null)
                    db.Purchases.Add(value);
                else
                    db.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(Int64 id, [FromBody]Purchase value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Purchases.Find(value.code) == null)
                    db.Purchases.Add(value);
                else
                    db.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
        }


        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(Int64 id)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                Purchase item = db.Purchases.Find(id);

                if (item != null)
                    db.Purchases.Remove(item);
            }
        }

        /// <summary>
        /// Dispose herança do controller
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
