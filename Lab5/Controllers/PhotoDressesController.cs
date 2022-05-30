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
    public class PhotoDressesController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public PhotoDressesController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/PhotoDresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDress>>> GetPhotoDresses()
        {
          if (_context.PhotoDresses == null)
          {
              return NotFound();
          }
            return await _context.PhotoDresses.ToListAsync();
        }

        // GET: api/PhotoDresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDress>> GetPhotoDress(int id)
        {
          if (_context.PhotoDresses == null)
          {
              return NotFound();
          }
            var photoDress = await _context.PhotoDresses.FindAsync(id);

            if (photoDress == null)
            {
                return NotFound();
            }

            return photoDress;
        }

        // PUT: api/PhotoDresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoDress(int id, PhotoDress photoDress)
        {
            if (id != photoDress.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoDress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoDressExists(id))
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

        // POST: api/PhotoDresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoDress>> PostPhotoDress(PhotoDress photoDress)
        {
          if (_context.PhotoDresses == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.PhotoDresses'  is null.");
          }
            _context.PhotoDresses.Add(photoDress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoDress", new { id = photoDress.Id }, photoDress);
        }

        // DELETE: api/PhotoDresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoDress(int id)
        {
            if (_context.PhotoDresses == null)
            {
                return NotFound();
            }
            var photoDress = await _context.PhotoDresses.FindAsync(id);
            if (photoDress == null)
            {
                return NotFound();
            }

            _context.PhotoDresses.Remove(photoDress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoDressExists(int id)
        {
            return (_context.PhotoDresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
