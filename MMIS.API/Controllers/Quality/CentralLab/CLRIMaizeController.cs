using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.CentralLab.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class CLRIMaizeController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLRIMaizeController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLRIMaize
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLMaizeRI>>> GetQualityCLRIMaize()
        {
            return await _context.QualityCLRIMaize.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLMaizeRI>>> GetQualityCLRIMaize(string Plant)
        //{
        //    return await _context.QualityCLRIMaize.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLRIMaize/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLMaizeRI>> GetCLMaizeRI(int id)
        {
            var cLMaizeRI = await _context.QualityCLRIMaize.FindAsync(id);

            if (cLMaizeRI == null)
            {
                return NotFound();
            }

            return cLMaizeRI;
        }

        // PUT: api/CLRIMaize/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLMaizeRI(int id, CLMaizeRI cLMaizeRI)
        {
            if (id != cLMaizeRI.Id)
            {
                return BadRequest();
            }
            cLMaizeRI.Modified = DateTime.Now;
            _context.Entry(cLMaizeRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLMaizeRIExists(id))
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

        // POST: api/CLRIMaize
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLMaizeRI>> PostCLMaizeRI(CLMaizeRI cLMaizeRI)
        {
            cLMaizeRI.Created = DateTime.Now;
            cLMaizeRI.Modified = cLMaizeRI.Created;
            _context.QualityCLRIMaize.Add(cLMaizeRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLMaizeRI", new { id = cLMaizeRI.Id }, cLMaizeRI);
        }

        // DELETE: api/CLRIMaize/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLMaizeRI>> DeleteCLMaizeRI(int id)
        {
            var cLMaizeRI = await _context.QualityCLRIMaize.FindAsync(id);
            if (cLMaizeRI == null)
            {
                return NotFound();
            }

            _context.QualityCLRIMaize.Remove(cLMaizeRI);
            await _context.SaveChangesAsync();

            return cLMaizeRI;
        }

        private bool CLMaizeRIExists(int id)
        {
            return _context.QualityCLRIMaize.Any(e => e.Id == id);
        }
    }
}
