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
    public class SizeTrousersController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public SizeTrousersController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/SizeTrousers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeTrousers>>> GetSizeTrousers()
        {
          if (_context.SizeTrousers == null)
          {
              return NotFound();
          }
            return await _context.SizeTrousers.ToListAsync();
        }

        // GET: api/SizeTrousers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeTrousers>> GetSizeTrousers(int id)
        {
          if (_context.SizeTrousers == null)
          {
              return NotFound();
          }
            var sizeTrousers = await _context.SizeTrousers.FindAsync(id);

            if (sizeTrousers == null)
            {
                return NotFound();
            }

            return sizeTrousers;
        }

        // PUT: api/SizeTrousers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeTrousers(int id, SizeTrousers sizeTrousers)
        {
            if (id != sizeTrousers.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeTrousers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeTrousersExists(id))
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

        // POST: api/SizeTrousers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeTrousers>> PostSizeTrousers(SizeTrousers sizeTrousers)
        {
          if (_context.SizeTrousers == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.SizeTrousers'  is null.");
          }
            _context.SizeTrousers.Add(sizeTrousers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeTrousers", new { id = sizeTrousers.Id }, sizeTrousers);
        }

        // DELETE: api/SizeTrousers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeTrousers(int id)
        {
            if (_context.SizeTrousers == null)
            {
                return NotFound();
            }
            var sizeTrousers = await _context.SizeTrousers.FindAsync(id);
            if (sizeTrousers == null)
            {
                return NotFound();
            }

            _context.SizeTrousers.Remove(sizeTrousers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeTrousersExists(int id)
        {
            return (_context.SizeTrousers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
