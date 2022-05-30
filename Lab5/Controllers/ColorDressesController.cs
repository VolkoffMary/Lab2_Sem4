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
    public class ColorDressesController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public ColorDressesController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/ColorDresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorDress>>> GetColorDresses()
        {
          if (_context.ColorDresses == null)
          {
              return NotFound();
          }
            return await _context.ColorDresses.ToListAsync();
        }

        // GET: api/ColorDresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDress>> GetColorDress(int id)
        {
          if (_context.ColorDresses == null)
          {
              return NotFound();
          }
            var colorDress = await _context.ColorDresses.FindAsync(id);

            if (colorDress == null)
            {
                return NotFound();
            }

            return colorDress;
        }

        // PUT: api/ColorDresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorDress(int id, ColorDress colorDress)
        {
            if (id != colorDress.Id)
            {
                return BadRequest();
            }

            _context.Entry(colorDress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorDressExists(id))
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

        // POST: api/ColorDresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColorDress>> PostColorDress(ColorDress colorDress)
        {
          if (_context.ColorDresses == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.ColorDresses'  is null.");
          }
            _context.ColorDresses.Add(colorDress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColorDress", new { id = colorDress.Id }, colorDress);
        }

        // DELETE: api/ColorDresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorDress(int id)
        {
            if (_context.ColorDresses == null)
            {
                return NotFound();
            }
            var colorDress = await _context.ColorDresses.FindAsync(id);
            if (colorDress == null)
            {
                return NotFound();
            }

            _context.ColorDresses.Remove(colorDress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorDressExists(int id)
        {
            return (_context.ColorDresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
