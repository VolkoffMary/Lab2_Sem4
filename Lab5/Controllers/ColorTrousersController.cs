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
    public class ColorTrousersController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public ColorTrousersController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/ColorTrousers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorTrousers>>> GetColorTrousers()
        {
          if (_context.ColorTrousers == null)
          {
              return NotFound();
          }
            return await _context.ColorTrousers.ToListAsync();
        }

        // GET: api/ColorTrousers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorTrousers>> GetColorTrousers(int id)
        {
          if (_context.ColorTrousers == null)
          {
              return NotFound();
          }
            var colorTrousers = await _context.ColorTrousers.FindAsync(id);

            if (colorTrousers == null)
            {
                return NotFound();
            }

            return colorTrousers;
        }

        // PUT: api/ColorTrousers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorTrousers(int id, ColorTrousers colorTrousers)
        {
            if (id != colorTrousers.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorTrousers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorTrousersExists(id))
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

        // POST: api/ColorTrousers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColorTrousers>> PostColorTrousers(ColorTrousers colorTrousers)
        {
          if (_context.ColorTrousers == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.ColorTrousers'  is null.");
          }
            _context.ColorTrousers.Add(colorTrousers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorTrousers", new { id = colorTrousers.Id }, colorTrousers);
        }

        // DELETE: api/ColorTrousers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorTrousers(int id)
        {
            if (_context.ColorTrousers == null)
            {
                return NotFound();
            }
            var colorTrousers = await _context.ColorTrousers.FindAsync(id);
            if (colorTrousers == null)
            {
                return NotFound();
            }

            _context.ColorTrousers.Remove(colorTrousers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorTrousersExists(int id)
        {
            return (_context.ColorTrousers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
