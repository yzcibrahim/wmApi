using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace langApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangsController : ControllerBase
    {
        LangDbContext _ctx;
        public LangsController(LangDbContext context)
        {
            _ctx = context;
        }
        // GET: api/<LangsController>
        [HttpGet]
        public IEnumerable<Language> Get()
        {
            return _ctx.Languages.ToList();
        }

        // GET api/<LangsController>/5
        [HttpGet("{id}")]
        public Language Get(int id)
        {
            return _ctx.Languages.FirstOrDefault(c=>c.Id==id);
        }

        // POST api/<LangsController>
        [HttpPost]
        public void Post([FromBody] Language lng)
        {
        }

        // PUT api/<LangsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LangsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
