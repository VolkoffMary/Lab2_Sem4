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
    public class ColorSkirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public ColorSkirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/ColorSkirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorSkirt>>> GetColorSkirts()
        {
          if (_context.ColorSkirts == null)
          {
              return NotFound();
          }
            return await _context.ColorSkirts.ToListAsync();
        }

        // GET: api/ColorSkirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorSkirt>> GetColorSkirt(int id)
        {
          if (_context.ColorSkirts == null)
          {
              return NotFound();
          }
            var colorSkirt = await _context.ColorSkirts.FindAsync(id);

            if (colorSkirt == null)
            {
                return NotFound();
            }

            return colorSkirt;
        }

        // PUT: api/ColorSkirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorSkirt(int id, ColorSkirt colorSkirt)
        {
            if (id != colorSkirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorSkirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorSkirtExists(id))
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

        // POST: api/ColorSkirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColorSkirt>> PostColorSkirt(ColorSkirt colorSkirt)
        {
          if (_context.ColorSkirts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.ColorSkirts'  is null.");
          }
            _context.ColorSkirts.Add(colorSkirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorSkirt", new { id = colorSkirt.Id }, colorSkirt);
        }

        // DELETE: api/ColorSkirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorSkirt(int id)
        {
            if (_context.ColorSkirts == null)
            {
                return NotFound();
            }
            var colorSkirt = await _context.ColorSkirts.FindAsync(id);
            if (colorSkirt == null)
            {
                return NotFound();
            }

            _context.ColorSkirts.Remove(colorSkirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorSkirtExists(int id)
        {
            return (_context.ColorSkirts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
