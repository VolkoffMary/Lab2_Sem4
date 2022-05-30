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
    public class SizeDressesController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public SizeDressesController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/SizeDresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeDress>>> GetSizeDresses()
        {
          if (_context.SizeDresses == null)
          {
              return NotFound();
          }
            return await _context.SizeDresses.ToListAsync();
        }

        // GET: api/SizeDresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeDress>> GetSizeDress(int id)
        {
          if (_context.SizeDresses == null)
          {
              return NotFound();
          }
            var sizeDress = await _context.SizeDresses.FindAsync(id);

            if (sizeDress == null)
            {
                return NotFound();
            }

            return sizeDress;
        }

        // PUT: api/SizeDresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeDress(int id, SizeDress sizeDress)
        {
            if (id != sizeDress.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeDress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeDressExists(id))
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

        // POST: api/SizeDresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeDress>> PostSizeDress(SizeDress sizeDress)
        {
          if (_context.SizeDresses == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.SizeDresses'  is null.");
          }
            _context.SizeDresses.Add(sizeDress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeDress", new { id = sizeDress.Id }, sizeDress);
        }

        // DELETE: api/SizeDresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeDress(int id)
        {
            if (_context.SizeDresses == null)
            {
                return NotFound();
            }
            var sizeDress = await _context.SizeDresses.FindAsync(id);
            if (sizeDress == null)
            {
                return NotFound();
            }

            _context.SizeDresses.Remove(sizeDress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeDressExists(int id)
        {
            return (_context.SizeDresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
