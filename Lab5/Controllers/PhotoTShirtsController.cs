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
    public class PhotoTShirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public PhotoTShirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/PhotoTShirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoTShirt>>> GetPhotoTShorts()
        {
          if (_context.PhotoTShorts == null)
          {
              return NotFound();
          }
            return await _context.PhotoTShorts.ToListAsync();
        }

        // GET: api/PhotoTShirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoTShirt>> GetPhotoTShirt(int id)
        {
          if (_context.PhotoTShorts == null)
          {
              return NotFound();
          }
            var photoTShirt = await _context.PhotoTShorts.FindAsync(id);

            if (photoTShirt == null)
            {
                return NotFound();
            }

            return photoTShirt;
        }

        // PUT: api/PhotoTShirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoTShirt(int id, PhotoTShirt photoTShirt)
        {
            if (id != photoTShirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoTShirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoTShirtExists(id))
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

        // POST: api/PhotoTShirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoTShirt>> PostPhotoTShirt(PhotoTShirt photoTShirt)
        {
          if (_context.PhotoTShorts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.PhotoTShorts'  is null.");
          }
            _context.PhotoTShorts.Add(photoTShirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoTShirt", new { id = photoTShirt.Id }, photoTShirt);
        }

        // DELETE: api/PhotoTShirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoTShirt(int id)
        {
            if (_context.PhotoTShorts == null)
            {
                return NotFound();
            }
            var photoTShirt = await _context.PhotoTShorts.FindAsync(id);
            if (photoTShirt == null)
            {
                return NotFound();
            }

            _context.PhotoTShorts.Remove(photoTShirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoTShirtExists(int id)
        {
            return (_context.PhotoTShorts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
