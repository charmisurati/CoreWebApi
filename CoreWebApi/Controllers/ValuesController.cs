using CoreWebApi.Database;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProjectDatabaseContext _context;

        public ValuesController()
        {
            this._context = new ProjectDatabaseContext();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost("login")]
        public IActionResult GetUsers([FromBody] LoginInModel loginInModel)
        {         
            var users = _context.UserData
               .Where(u => u.Email == loginInModel.Email && u.Password == loginInModel.Password)
               .ToList();
          
            if (users.Count > 0)
            {                
                return Ok(users.First());
            }
            // Authentication failed or no matching user with "ok" status.
            return Unauthorized("Invalid username or password");
        }

        [HttpPost("signup")]
        public int CreateUsers([FromBody] UserDatum user )
        {
            
            _context.UserData.Add(user);
            _context.SaveChanges();
            return user.UId;
            
            
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
