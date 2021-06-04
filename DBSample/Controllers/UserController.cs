using DBSample.DBContext;
using DBSample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _userContext.Users.ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await _userContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User _user)
        {
            User user = new()
            {
                Name = _user.Name,
                Age = _user.Age,
                DateOfBirth = _user.DateOfBirth,
                Address = _user.Address
            };

            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, Get(user.Id));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User _user)
        {
            User user = await _userContext.Users.FindAsync(id);
            if (id != _user.Id)
            {
                return BadRequest();
            }

            user.Name = _user.Name;
            user.DateOfBirth = _user.DateOfBirth;
            user.Age = _user.Age;
            user.Address = _user.Address;

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_userContext.Users.Any(a => a.Id == id))
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userContext.Users.Remove(user);
            await _userContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
