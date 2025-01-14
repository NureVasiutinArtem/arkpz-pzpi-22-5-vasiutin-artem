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
    public class TemplatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemplatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Template>>> GetTemplate()
        {
            return await _context.Template.ToListAsync();
        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplate(int id)
        {
            var template = await _context.Template.FindAsync(id);

            if (template == null)
            {
                return NotFound();
            }

            return template;
        }

        // PUT: api/Templates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplate(int id, Template template)
        {
            if (id != template.TemplateId)
            {
                return BadRequest();
            }

            _context.Entry(template).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
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

        // POST: api/Templates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate(Template template)
        {
            _context.Template.Add(template);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplate", new { id = template.TemplateId }, template);
        }

       

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            var template = await _context.Template.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            _context.Template.Remove(template);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemplateExists(int id)
        {
            return _context.Template.Any(e => e.TemplateId == id);
        }
    }
}
