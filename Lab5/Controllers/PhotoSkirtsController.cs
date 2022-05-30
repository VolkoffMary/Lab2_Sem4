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
    public class PhotoSkirtsController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public PhotoSkirtsController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/PhotoSkirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoSkirt>>> GetPhotoSkirts()
        {
          if (_context.PhotoSkirts == null)
          {
              return NotFound();
          }
            return await _context.PhotoSkirts.ToListAsync();
        }

        // GET: api/PhotoSkirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoSkirt>> GetPhotoSkirt(int id)
        {
          if (_context.PhotoSkirts == null)
          {
              return NotFound();
          }
            var photoSkirt = await _context.PhotoSkirts.FindAsync(id);

            if (photoSkirt == null)
            {
                return NotFound();
            }

            return photoSkirt;
        }

        // PUT: api/PhotoSkirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoSkirt(int id, PhotoSkirt photoSkirt)
        {
            if (id != photoSkirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoSkirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoSkirtExists(id))
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

        // POST: api/PhotoSkirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoSkirt>> PostPhotoSkirt(PhotoSkirt photoSkirt)
        {
          if (_context.PhotoSkirts == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.PhotoSkirts'  is null.");
          }
            _context.PhotoSkirts.Add(photoSkirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoSkirt", new { id = photoSkirt.Id }, photoSkirt);
        }

        // DELETE: api/PhotoSkirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoSkirt(int id)
        {
            if (_context.PhotoSkirts == null)
            {
                return NotFound();
            }
            var photoSkirt = await _context.PhotoSkirts.FindAsync(id);
            if (photoSkirt == null)
            {
                return NotFound();
            }

            _context.PhotoSkirts.Remove(photoSkirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoSkirtExists(int id)
        {
            return (_context.PhotoSkirts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
