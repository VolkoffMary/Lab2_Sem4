using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public SkirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/Skirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skirt>>> GetSkirts()
        {
          if (_context.Skirts == null)
          {
              return NotFound();
          }
            return await _context.Skirts.ToListAsync();
        }

        // GET: api/Skirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skirt>> GetSkirt(int id)
        {
          if (_context.Skirts == null)
          {
              return NotFound();
          }
            var skirt = await _context.Skirts.FindAsync(id);

            if (skirt == null)
            {
                return NotFound();
            }

            return skirt;
        }

        // PUT: api/Skirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkirt(int id, Skirt skirt)
        {
            if (id != skirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(skirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkirtExists(id))
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

        // POST: api/Skirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skirt>> PostSkirt(Skirt skirt)
        {
          if (_context.Skirts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.Skirts'  is null.");
          }
            _context.Skirts.Add(skirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkirt", new { id = skirt.Id }, skirt);
        }

        // DELETE: api/Skirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkirt(int id)
        {
            if (_context.Skirts == null)
            {
                return NotFound();
            }
            var skirt = await _context.Skirts.FindAsync(id);
            if (skirt == null)
            {
                return NotFound();
            }

            _context.Skirts.Remove(skirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkirtExists(int id)
        {
            return (_context.Skirts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
