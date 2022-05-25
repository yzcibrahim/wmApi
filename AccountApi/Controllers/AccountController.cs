using AccountApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        [Authorize]
        public IEnumerable<WordUser> Get()
        {
            return _context.WordUsers.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public WordUser Get(int id)
        {
            return _context.WordUsers.FirstOrDefault(c => c.Id == id);
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

        [HttpPost("Authenticate")]
        public string Authenticate([FromBody] WordUser userInfo)
        {
            var loggedUser = _context.WordUsers.FirstOrDefault(c => c.Password == userInfo.Password && c.UserName == userInfo.UserName);

            if (loggedUser != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("TUAUTKEY--ASD-SECTETKEY");

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                   new Claim[]
                   {
                        new Claim(ClaimTypes.Name, loggedUser.UserName),
                        new Claim(ClaimTypes.Role,"admin")

                   }),
                   Expires = DateTime.UtcNow.AddMinutes(10),

                    SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            return "";
        }
    }
}
