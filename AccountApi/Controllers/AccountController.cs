using AccountApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly AccountContext _context;
        public AccountController(AccountContext context)
        {
            _context = context;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<WordUser> Get()
        {
            return _context.WordUsers.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public WordUser Get(int id)
        {
            return _context.WordUsers.FirstOrDefault(c=>c.Id==id);
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] WordUser entity)
        {
            _context.WordUsers.Add(entity);
            _context.SaveChanges();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
