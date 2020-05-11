using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiEDU.Models;
using WebApiEDU.Models.ModelsContext;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEDU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _dbcontext;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int? id)
        {
            User user;
            
            if (id == null ||
                (user = await _dbcontext.Users.FirstOrDefaultAsync(user => user.Id == id)) == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _dbcontext.AddAsync(user);

            await _dbcontext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            User userFinded;
            
            if (user == null || 
                (userFinded =await _dbcontext.Users.FirstOrDefaultAsync(userdb => userdb.Id == user.Id)) == null)
            {
                return NotFound();
            }

            _dbcontext.Entry(user).State = EntityState.Modified;
            
            //_dbcontext.Update(user);
            await _dbcontext.SaveChangesAsync();

            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
            return Ok(user);
        }


        public UsersController(ApplicationContext dbContext)
        {
            _dbcontext = dbContext;

            if (!_dbcontext.Users.Any())
            {
                _dbcontext.Users.Add(new User { Name = "Tom", Age = 26 });
                _dbcontext.Users.Add(new User { Name = "Alice", Age = 31 });
                _dbcontext.SaveChanges();
            }
        }
    }
}

#region read
//// GET: api/<controller>
//[HttpGet]
//public IEnumerable<string> Get()
//{
//    return new string[] { "value1", "value2" };
//}

//// GET api/<controller>/5
//[HttpGet("{id}")]
//public string Get(int id)
//{
//    return "value";
//}

//// POST api/<controller>
//[HttpPost]
//public void Post([FromBody]string value)
//{
//    string tt = value;
//}

//// PUT api/<controller>/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody]string value)
//{
//}

//// DELETE api/<controller>/5
//[HttpDelete("{id}")]
//public void Delete(int id)
//{
//}

#endregion