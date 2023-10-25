using CoreWebApi.Database;
using CoreWebApi.Helper;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto.Generators;
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
                string token = TokenManager.GenerateToken(loginInModel.Email, loginInModel.Password);
                //return Ok(users.First());
                return Ok(token);
            }
            // Authentication failed or no matching user with "ok" status.
            return Unauthorized("Invalid username or password");
        }

        [HttpPost("signup")]
        public IActionResult CreateUsers([FromBody] SignUpModel signUp)
        {

            if (_context.UserData.Any(u => u.Email == signUp.Email))
            {

                return BadRequest("User with this email already exists.");
            }

            else
            {

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(signUp.Password);

                UserDatum newUser = new UserDatum
                {
                    FirstName = signUp.FirstName,
                    LastName = signUp.LastName,
                    Email = signUp.Email,
                    Password = passwordHash
                };

                // Add the new user to the database
                _context.UserData.Add(newUser);
                _context.SaveChanges();

                // Return a response indicating success with the sign-up model
                return StatusCode(200,signUp);
            }

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
