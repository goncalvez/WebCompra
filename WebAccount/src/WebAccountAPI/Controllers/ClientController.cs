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
    public class ClientController : Controller
    {
        /// <summary>
        /// Contexto para gerenciar informações com a base de dados
        /// </summary>
        private MyContext db = new MyContext(new DbContextOptions<MyContext>());

        /// <summary>
        /// GET: api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Clients.ToList();
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
                return db.Clients.Find(id);
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]Client value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Clients.Find(value.code) == null)
                    db.Clients.Add(value);
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
        public void Put(int id, [FromBody]Client value)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                if (db.Clients.Find(value.code) == null)
                    db.Clients.Add(value);
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
        public void Delete(int id)
        {
            using (MyContext db = new MyContext(new DbContextOptions<MyContext>()))
            {
                Client item = db.Clients.Find(id);

                if (item != null)
                    db.Clients.Remove(item);
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
