using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaresAPI.Models;
using Microsoft.AspNetCore.Authorization;
using APIMares.Authentication;

namespace APIMares.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TidesController : ControllerBase
    {
        private readonly MaresAPIContext _context;

        public TidesController(MaresAPIContext context)
        {
            _context = context;
        }

        // GET: api/Tides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tide>>> GetTides()
        {
            return await _context.Tides.ToListAsync();
        }

        // GET: api/Tides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tide>> GetTide(int id)
        {
            var tide = await _context.Tides.FindAsync(id);

            if (tide == null)
            {
                return NotFound();
            }

            return tide;
        }

        // PUT: api/Tides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTide(int id, Tide tide)
        {
            if (id != tide.Id)
            {
                return BadRequest();
            }

            _context.Entry(tide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TideExists(id))
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

        // POST: api/Tides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tide>> PostTide(Tide tide)
        {
            _context.Tides.Add(tide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTide", new { id = tide.Id }, tide);
        }

        // DELETE: api/Tides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTide(int id)
        {
            var tide = await _context.Tides.FindAsync(id);
            if (tide == null)
            {
                return NotFound();
            }

            _context.Tides.Remove(tide);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TideExists(int id)
        {
            return _context.Tides.Any(e => e.Id == id);
        }

        //comando para dar permissão ao admin de aceder a esta chamada de metodo
        [Authorize(Roles = UserRoles.Admin)]
        // Controlador da pesquisa da praia através do conselho
        //GET: api/Tides/makeTide/1
        [HttpGet("getBeach/beach={beach}")]
        public async Task<ActionResult<List<Tide>>> GetBeach(int beach)
        {
            List<Tide> tides = await _context.Tides.Where(c => c.BeachId == beach).ToListAsync();
            if (tides.Count() > 0)
            {
                return tides;
            }
            else {
                return NotFound();
            }
        }


        //GET: api/Tides/getDay/1
        [HttpGet("getDay/day={day}")]
        public async Task<ActionResult<List<Tide>>> GetDay(DateTime day) 
        {
            List<Tide> tides = await _context.Tides.Where(c => c.Day == day).ToListAsync();
            if (tides.Count() > 0)
            {
                return tides;
            }
            else {

                return NotFound();
            }
        }
    }



}
