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
    public class ColorTShirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public ColorTShirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/ColorTShirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorTShirt>>> GetColorTShorts()
        {
          if (_context.ColorTShorts == null)
          {
              return NotFound();
          }
            return await _context.ColorTShorts.ToListAsync();
        }

        // GET: api/ColorTShirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorTShirt>> GetColorTShirt(int id)
        {
          if (_context.ColorTShorts == null)
          {
              return NotFound();
          }
            var colorTShirt = await _context.ColorTShorts.FindAsync(id);

            if (colorTShirt == null)
            {
                return NotFound();
            }

            return colorTShirt;
        }

        // PUT: api/ColorTShirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorTShirt(int id, ColorTShirt colorTShirt)
        {
            if (id != colorTShirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorTShirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorTShirtExists(id))
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

        // POST: api/ColorTShirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColorTShirt>> PostColorTShirt(ColorTShirt colorTShirt)
        {
          if (_context.ColorTShorts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.ColorTShorts'  is null.");
          }
            _context.ColorTShorts.Add(colorTShirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorTShirt", new { id = colorTShirt.Id }, colorTShirt);
        }

        // DELETE: api/ColorTShirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorTShirt(int id)
        {
            if (_context.ColorTShorts == null)
            {
                return NotFound();
            }
            var colorTShirt = await _context.ColorTShorts.FindAsync(id);
            if (colorTShirt == null)
            {
                return NotFound();
            }

            _context.ColorTShorts.Remove(colorTShirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorTShirtExists(int id)
        {
            return (_context.ColorTShorts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
