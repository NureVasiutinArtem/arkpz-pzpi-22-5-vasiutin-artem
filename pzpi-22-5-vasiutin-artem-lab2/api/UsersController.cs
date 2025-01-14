using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using light_show.Data;
using light_show.Models;
using light_show.Models.auth;
using light_show.Models.NewFolder;

namespace light_show.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APIUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/APIUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/APIUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            users.CreatedAt= DateTime.Now;
            users.UserId = await _context.Users.CountAsync()+1;

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId ,}, users);
        }

        // DELETE: api/APIUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (string.IsNullOrEmpty(registerRequest.Username) || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password))
            {
                return BadRequest("Username, Email, and Password are required.");
            }

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == registerRequest.Email);
            if (existingUser != null)
            {
                return Conflict("User with this email already exists.");
            }


            var user = new Users
            {
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                PasswordHash = registerRequest.Password,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = user.UserId} ,user);
        }
        // POST: api/APIUsers/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (existingUser == null)
            {
                return Unauthorized("Invalid email or password.");
            }

           
            if (existingUser.PasswordHash != loginRequest.Password)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(new { message = "Login successful", user = existingUser });
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        
    }
}
