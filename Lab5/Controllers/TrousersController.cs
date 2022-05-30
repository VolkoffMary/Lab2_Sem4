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
    public class TrousersController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public TrousersController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/Trousers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trousers>>> GetTrousers()
        {
          if (_context.Trousers == null)
          {
              return NotFound();
          }
            return await _context.Trousers.ToListAsync();
        }

        // GET: api/Trousers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trousers>> GetTrousers(int id)
        {
          if (_context.Trousers == null)
          {
              return NotFound();
          }
            var trousers = await _context.Trousers.FindAsync(id);

            if (trousers == null)
            {
                return NotFound();
            }

            return trousers;
        }

        // PUT: api/Trousers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrousers(int id, Trousers trousers)
        {
            if (id != trousers.Id)
            {
                return BadRequest();
            }

            _context.Entry(trousers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrousersExists(id))
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

        // POST: api/Trousers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trousers>> PostTrousers(Trousers trousers)
        {
          if (_context.Trousers == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.Trousers'  is null.");
          }
            _context.Trousers.Add(trousers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrousers", new { id = trousers.Id }, trousers);
        }

        // DELETE: api/Trousers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrousers(int id)
        {
            if (_context.Trousers == null)
            {
                return NotFound();
            }
            var trousers = await _context.Trousers.FindAsync(id);
            if (trousers == null)
            {
                return NotFound();
            }

            _context.Trousers.Remove(trousers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrousersExists(int id)
        {
            return (_context.Trousers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
