using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceAgendaPraticien.Data;
using ServiceAgendaPraticien.Model;

namespace ServiceAgendaPraticien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraticiensController : ControllerBase
    {
        private readonly ServiceAgendaPraticienContext _context;

        public PraticiensController(ServiceAgendaPraticienContext context)
        {
            _context = context;
        }

        // GET: api/Praticiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Praticien>>> GetPraticien()
        {
          if (_context.Praticien == null)
          {
              return NotFound();
          }
            return await _context.Praticien.ToListAsync();
        }

        // GET: api/Praticiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Praticien>> GetPraticien(int id)
        {
          if (_context.Praticien == null)
          {
              return NotFound();
          }
            var praticien = await _context.Praticien.FindAsync(id);

            if (praticien == null)
            {
                return NotFound();
            }

            return praticien;
        }

        // PUT: api/Praticiens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPraticien(int id, Praticien praticien)
        {
            if (id != praticien.Id)
            {
                return BadRequest();
            }

            _context.Entry(praticien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PraticienExists(id))
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

        // POST: api/Praticiens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Praticien>> PostPraticien(Praticien praticien)
        {
          if (_context.Praticien == null)
          {
              return Problem("Entity set 'ServiceAgendaPraticienContext.Praticien'  is null.");
          }
            _context.Praticien.Add(praticien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPraticien", new { id = praticien.Id }, praticien);
        }

        // DELETE: api/Praticiens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePraticien(int id)
        {
            if (_context.Praticien == null)
            {
                return NotFound();
            }
            var praticien = await _context.Praticien.FindAsync(id);
            if (praticien == null)
            {
                return NotFound();
            }

            _context.Praticien.Remove(praticien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PraticienExists(int id)
        {
            return (_context.Praticien?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
