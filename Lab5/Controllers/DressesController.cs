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
    public class DressesController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public DressesController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/Dresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dress>>> GetDresses()
        {
          if (_context.Dresses == null)
          {
              return NotFound();
          }
            return await _context.Dresses.ToListAsync();
        }

        // GET: api/Dresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dress>> GetDress(int id)
        {
          if (_context.Dresses == null)
          {
              return NotFound();
          }
            var dress = await _context.Dresses.FindAsync(id);

            if (dress == null)
            {
                return NotFound();
            }

            return dress;
        }

        // PUT: api/Dresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDress(int id, Dress dress)
        {
            if (id != dress.Id)
            {
                return BadRequest();
            }

            _context.Entry(dress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DressExists(id))
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

        // POST: api/Dresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dress>> PostDress(Dress dress)
        {
          if (_context.Dresses == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.Dresses'  is null.");
          }
            _context.Dresses.Add(dress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDress", new { id = dress.Id }, dress);
        }

        // DELETE: api/Dresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDress(int id)
        {
            if (_context.Dresses == null)
            {
                return NotFound();
            }
            var dress = await _context.Dresses.FindAsync(id);
            if (dress == null)
            {
                return NotFound();
            }

            _context.Dresses.Remove(dress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DressExists(int id)
        {
            return (_context.Dresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
