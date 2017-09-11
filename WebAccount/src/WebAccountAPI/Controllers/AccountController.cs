using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAccountAPI.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAccountAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// GET: api/accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Accounts.ToList();
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Account Get(Int64 id)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Accounts.Find(id);
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("RegistryClient")]
        public void Post([FromBody]Account value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Accounts.Find(value.code) == null)
                    db.Accounts.Add(value);
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
        public void Put(Int64 id, [FromBody]Account value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Accounts.Find(value.code) == null)
                    db.Accounts.Add(value);
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
                Account item = db.Accounts.Find(id);

                if (item != null)
                    db.Accounts.Remove(item);
            }
        }

        /// <summary>
        /// Dispose herança do controller
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
