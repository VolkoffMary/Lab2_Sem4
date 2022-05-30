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
    public class PhotoTrousersController : ControllerBase
    {
        private readonly CatalogueAPIContext _context;

        public PhotoTrousersController(CatalogueAPIContext context)
        {
            _context = context;
        }

        // GET: api/PhotoTrousers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoTrousers>>> GetPhotoTrousers()
        {
          if (_context.PhotoTrousers == null)
          {
              return NotFound();
          }
            return await _context.PhotoTrousers.ToListAsync();
        }

        // GET: api/PhotoTrousers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoTrousers>> GetPhotoTrousers(int id)
        {
          if (_context.PhotoTrousers == null)
          {
              return NotFound();
          }
            var photoTrousers = await _context.PhotoTrousers.FindAsync(id);

            if (photoTrousers == null)
            {
                return NotFound();
            }

            return photoTrousers;
        }

        // PUT: api/PhotoTrousers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoTrousers(int id, PhotoTrousers photoTrousers)
        {
            if (id != photoTrousers.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoTrousers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoTrousersExists(id))
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

        // POST: api/PhotoTrousers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoTrousers>> PostPhotoTrousers(PhotoTrousers photoTrousers)
        {
          if (_context.PhotoTrousers == null)
          {
              return Problem("Entity set 'CatalogueAPIContext.PhotoTrousers'  is null.");
          }
            _context.PhotoTrousers.Add(photoTrousers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoTrousers", new { id = photoTrousers.Id }, photoTrousers);
        }

        // DELETE: api/PhotoTrousers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoTrousers(int id)
        {
            if (_context.PhotoTrousers == null)
            {
                return NotFound();
            }
            var photoTrousers = await _context.PhotoTrousers.FindAsync(id);
            if (photoTrousers == null)
            {
                return NotFound();
            }

            _context.PhotoTrousers.Remove(photoTrousers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoTrousersExists(int id)
        {
            return (_context.PhotoTrousers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
