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


    public class CLRISorghumController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLRISorghumController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLRISorghum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLSorghumRI>>> GetQualityCLRISorghum()
        {
            return await _context.QualityCLRISorghum.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLSorghumRI>>> GetQualityCLRISorghum([FromQuery]string Batch)
        //{
        //    return await _context.QualityCLRISorghum.Where(m => m.BatchNumber == Batch).ToListAsync();
        //}

        // GET: api/CLRISorghum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLSorghumRI>> GetCLSorghumRI(int id)
        {
            var cLSorghumRI = await _context.QualityCLRISorghum.FindAsync(id);

            if (cLSorghumRI == null)
            {
                return NotFound();
            }

            return cLSorghumRI;
        }

        // PUT: api/CLRISorghum/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLSorghumRI(int id, CLSorghumRI cLSorghumRI)
        {
            if (id != cLSorghumRI.Id)
            {
                return BadRequest();
            }
            cLSorghumRI.Modified = DateTime.Now;
            _context.Entry(cLSorghumRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLSorghumRIExists(id))
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

        // POST: api/CLRISorghum
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLSorghumRI>> PostCLSorghumRI(CLSorghumRI cLSorghumRI)
        {
            cLSorghumRI.Created = DateTime.Now;
            cLSorghumRI.Modified = cLSorghumRI.Created;

            _context.QualityCLRISorghum.Add(cLSorghumRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLSorghumRI", new { id = cLSorghumRI.Id }, cLSorghumRI);
        }

        // DELETE: api/CLRISorghum/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLSorghumRI>> DeleteCLSorghumRI(int id)
        {
            var cLSorghumRI = await _context.QualityCLRISorghum.FindAsync(id);
            if (cLSorghumRI == null)
            {
                return NotFound();
            }

            _context.QualityCLRISorghum.Remove(cLSorghumRI);
            await _context.SaveChangesAsync();

            return cLSorghumRI;
        }

        private bool CLSorghumRIExists(int id)
        {
            return _context.QualityCLRISorghum.Any(e => e.Id == id);
        }
    }
}
