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


    public class CLRIYeastController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLRIYeastController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLRIYeast
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLYeastRI>>> GetQualityCLRIYeast()
        {
            return await _context.QualityCLRIYeast.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLYeastRI>>> GetQualityCLRIYeast([FromQuery]string Batch)
        //{
        //    return await _context.QualityCLRIYeast.Where(m => m.BatchNumber == Batch).ToListAsync();
        //}

        // GET: api/CLRIYeast/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLYeastRI>> GetCLYeastRI(int id)
        {
            var cLYeastRI = await _context.QualityCLRIYeast.FindAsync(id);

            if (cLYeastRI == null)
            {
                return NotFound();
            }

            return cLYeastRI;
        }

        // PUT: api/CLRIYeast/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLYeastRI(int id, CLYeastRI cLYeastRI)
        {
            if (id != cLYeastRI.Id)
            {
                return BadRequest();
            }
            cLYeastRI.Modified = DateTime.Now;
            _context.Entry(cLYeastRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLYeastRIExists(id))
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

        // POST: api/CLRIYeast
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLYeastRI>> PostCLYeastRI(CLYeastRI cLYeastRI)
        {
            cLYeastRI.Created = DateTime.Now;
            cLYeastRI.Modified = cLYeastRI.Created;

            _context.QualityCLRIYeast.Add(cLYeastRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLYeastRI", new { id = cLYeastRI.Id }, cLYeastRI);
        }

        // DELETE: api/CLRIYeast/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLYeastRI>> DeleteCLYeastRI(int id)
        {
            var cLYeastRI = await _context.QualityCLRIYeast.FindAsync(id);
            if (cLYeastRI == null)
            {
                return NotFound();
            }

            _context.QualityCLRIYeast.Remove(cLYeastRI);
            await _context.SaveChangesAsync();

            return cLYeastRI;
        }

        private bool CLYeastRIExists(int id)
        {
            return _context.QualityCLRIYeast.Any(e => e.Id == id);
        }
    }
}
