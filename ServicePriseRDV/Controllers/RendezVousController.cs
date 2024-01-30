using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicePriseRDV.Data;
using ServicePriseRDV.Model;

namespace ServicePriseRDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly ServicePriseRDVContext _context;

        public RendezVousController(ServicePriseRDVContext context)
        {
            _context = context;
        }

        // GET: api/RendezVous
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RendezVous>>> GetRendezVous()
        {
          if (_context.RendezVous == null)
          {
              return NotFound();
          }
            return await _context.RendezVous.ToListAsync();
        }

        // GET: api/RendezVous/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RendezVous>> GetRendezVous(int id)
        {
          if (_context.RendezVous == null)
          {
              return NotFound();
          }
            var rendezVous = await _context.RendezVous.FindAsync(id);

            if (rendezVous == null)
            {
                return NotFound();
            }

            return rendezVous;
        }

        // PUT: api/RendezVous/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRendezVous(int id, RendezVous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return BadRequest();
            }

            _context.Entry(rendezVous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RendezVousExists(id))
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

        // POST: api/RendezVous
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RendezVous>> PostRendezVous(RendezVous rendezVous)
        {
          if (_context.RendezVous == null)
          {
              return Problem("Entity set 'ServicePriseRDVContext.RendezVous'  is null.");
          }
            _context.RendezVous.Add(rendezVous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRendezVous", new { id = rendezVous.Id }, rendezVous);
        }

        // DELETE: api/RendezVous/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRendezVous(int id)
        {
            if (_context.RendezVous == null)
            {
                return NotFound();
            }
            var rendezVous = await _context.RendezVous.FindAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            _context.RendezVous.Remove(rendezVous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RendezVousExists(int id)
        {
            return (_context.RendezVous?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
