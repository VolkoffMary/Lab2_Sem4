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
    public class TShirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public TShirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/TShirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShirt>>> GetTShorts()
        {
          if (_context.TShorts == null)
          {
              return NotFound();
          }
            return await _context.TShorts.ToListAsync();
        }

        // GET: api/TShirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TShirt>> GetTShirt(int id)
        {
          if (_context.TShorts == null)
          {
              return NotFound();
          }
            var tShirt = await _context.TShorts.FindAsync(id);

            if (tShirt == null)
            {
                return NotFound();
            }

            return tShirt;
        }

        // PUT: api/TShirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTShirt(int id, TShirt tShirt)
        {
            if (id != tShirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(tShirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TShirtExists(id))
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

        // POST: api/TShirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TShirt>> PostTShirt(TShirt tShirt)
        {
          if (_context.TShorts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.TShorts'  is null.");
          }
            //tShirt.Brand = await _context.Brands.FindAsync(tShirt.BrandId);
            //ModelState.ClearValidationState(nameof(tShirt));
            //ModelState.ClearValidationState(nameof(tShirt.Brand));
            //TryValidateModel(tShirt.Brand, nameof(tShirt.Brand));
            //TryValidateModel(tShirt, nameof(tShirt));
            _context.TShorts.Add(tShirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTShirt", new { id = tShirt.Id }, tShirt);
        }

        // DELETE: api/TShirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTShirt(int id)
        {
            if (_context.TShorts == null)
            {
                return NotFound();
            }
            var tShirt = await _context.TShorts.FindAsync(id);
            if (tShirt == null)
            {
                return NotFound();
            }

            _context.TShorts.Remove(tShirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TShirtExists(int id)
        {
            return (_context.TShorts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
