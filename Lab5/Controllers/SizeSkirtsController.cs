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
    public class SizeSkirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public SizeSkirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/SizeSkirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeSkirt>>> GetSizeSkirts()
        {
          if (_context.SizeSkirts == null)
          {
              return NotFound();
          }
            return await _context.SizeSkirts.ToListAsync();
        }

        // GET: api/SizeSkirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeSkirt>> GetSizeSkirt(int id)
        {
          if (_context.SizeSkirts == null)
          {
              return NotFound();
          }
            var sizeSkirt = await _context.SizeSkirts.FindAsync(id);

            if (sizeSkirt == null)
            {
                return NotFound();
            }

            return sizeSkirt;
        }

        // PUT: api/SizeSkirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeSkirt(int id, SizeSkirt sizeSkirt)
        {
            if (id != sizeSkirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeSkirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeSkirtExists(id))
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

        // POST: api/SizeSkirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeSkirt>> PostSizeSkirt(SizeSkirt sizeSkirt)
        {
          if (_context.SizeSkirts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.SizeSkirts'  is null.");
          }
            _context.SizeSkirts.Add(sizeSkirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeSkirt", new { id = sizeSkirt.Id }, sizeSkirt);
        }

        // DELETE: api/SizeSkirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeSkirt(int id)
        {
            if (_context.SizeSkirts == null)
            {
                return NotFound();
            }
            var sizeSkirt = await _context.SizeSkirts.FindAsync(id);
            if (sizeSkirt == null)
            {
                return NotFound();
            }

            _context.SizeSkirts.Remove(sizeSkirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeSkirtExists(int id)
        {
            return (_context.SizeSkirts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
