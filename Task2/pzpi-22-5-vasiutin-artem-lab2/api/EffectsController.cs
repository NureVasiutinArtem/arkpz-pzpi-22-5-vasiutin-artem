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
    public class EffectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EffectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APIEffects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Effect>>> GetEffect()
        {
            return await _context.Effect.ToListAsync();
        }

        // GET: api/APIEffects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Effect>> GetEffect(int id)
        {
            var effect = await _context.Effect.FindAsync(id);

            if (effect == null)
            {
                return NotFound();
            }

            return effect;
        }

        // PUT: api/APIEffects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEffect(int id, Effect effect)
        {
            if (id != effect.EffectId)
            {
                return BadRequest();
            }

            _context.Entry(effect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectExists(id))
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

        // POST: api/APIEffects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Effect>> PostEffect(Effect effect)
        {
            _context.Effect.Add(effect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEffect", new { id = effect.EffectId }, effect);
        }

        // DELETE: api/APIEffects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEffect(int id)
        {
            var effect = await _context.Effect.FindAsync(id);
            if (effect == null)
            {
                return NotFound();
            }

            _context.Effect.Remove(effect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EffectExists(int id)
        {
            return _context.Effect.Any(e => e.EffectId == id);
        }
    }
}
