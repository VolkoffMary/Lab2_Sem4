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
    public class SizeTShirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public SizeTShirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/SizeTShirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeTShirt>>> GetSizeTShorts()
        {
          if (_context.SizeTShorts == null)
          {
              return NotFound();
          }
            return await _context.SizeTShorts.ToListAsync();
        }

        // GET: api/SizeTShirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeTShirt>> GetSizeTShirt(int id)
        {
          if (_context.SizeTShorts == null)
          {
              return NotFound();
          }
            var sizeTShirt = await _context.SizeTShorts.FindAsync(id);

            if (sizeTShirt == null)
            {
                return NotFound();
            }

            return sizeTShirt;
        }

        // PUT: api/SizeTShirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeTShirt(int id, SizeTShirt sizeTShirt)
        {
            if (id != sizeTShirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeTShirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeTShirtExists(id))
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

        // POST: api/SizeTShirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeTShirt>> PostSizeTShirt(SizeTShirt sizeTShirt)
        {
          if (_context.SizeTShorts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.SizeTShorts'  is null.");
          }
            _context.SizeTShorts.Add(sizeTShirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeTShirt", new { id = sizeTShirt.Id }, sizeTShirt);
        }

        // DELETE: api/SizeTShirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeTShirt(int id)
        {
            if (_context.SizeTShorts == null)
            {
                return NotFound();
            }
            var sizeTShirt = await _context.SizeTShorts.FindAsync(id);
            if (sizeTShirt == null)
            {
                return NotFound();
            }

            _context.SizeTShorts.Remove(sizeTShirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeTShirtExists(int id)
        {
            return (_context.SizeTShorts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
