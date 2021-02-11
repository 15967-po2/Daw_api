using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaresAPI.Models;

namespace APIMares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeachesController : ControllerBase
    {
        private readonly MaresAPIContext _context;

        public BeachesController(MaresAPIContext context)
        {
            _context = context;
        }

        // GET: api/Beaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beach>>> GetBeaches()
        {
            return await _context.Beaches.ToListAsync();
        }

        // GET: api/Beaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beach>> GetBeach(int id)
        {
            var beach = await _context.Beaches.FindAsync(id);

            if (beach == null)
            {
                return NotFound();
            }

            return beach;
        }

        // PUT: api/Beaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeach(int id, Beach beach)
        {
            if (id != beach.Id)
            {
                return BadRequest();
            }

            _context.Entry(beach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeachExists(id))
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

        // POST: api/Beaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beach>> PostBeach(Beach beach)
        {
            _context.Beaches.Add(beach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeach", new { id = beach.Id }, beach);
        }

        // DELETE: api/Beaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeach(int id)
        {
            var beach = await _context.Beaches.FindAsync(id);
            if (beach == null)
            {
                return NotFound();
            }

            _context.Beaches.Remove(beach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeachExists(int id)
        {
            return _context.Beaches.Any(e => e.Id == id);
        }

        //controlador da pesquisa de praias pelo concelho
        //get: api/tides/makebeach/1
        [HttpGet("getBeaches/county={county}")]
        public async Task<ActionResult<List<Beach>>> getBeaches(int county)
        {
            List<Beach> beaches = await _context.Beaches.Where(c => c.CountyId == county).ToListAsync();
            if (beaches.Count() > 0)
            {
                return beaches;
            }
            else
            {
                return NotFound();
            }
        }

        ////GET: api/Tides/makeTide/1
        //[HttpGet("getTides/beach={beach}")]
        //public async Task<ActionResult<List<Tide>>> getTides(int beach)
        //{
        //    List<Tide> tides = await _context.Tides.Where(c => c.BeachId == beach).ToListAsync();
        //    if (tides.Count() > 0)
        //    {
        //        return tides;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

    }
}
