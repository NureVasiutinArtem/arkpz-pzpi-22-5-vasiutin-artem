using light_show.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using light_show.Data;
using light_show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using light_show.Data;
using light_show.Models;

namespace light_show.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnalyticsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("new-users-last-week")]
        public async Task<IActionResult> GetNewUsersLastWeek()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);  

            var newUserCount = await _context.Users
                .Where(user => user.CreatedAt >= oneWeekAgo)  
                .CountAsync();  

            return Ok(new { NewUserCount = newUserCount });
        }
    }

}
