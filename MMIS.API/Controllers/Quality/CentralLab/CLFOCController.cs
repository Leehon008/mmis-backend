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


    public class CLFOCController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLFOCController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLFOC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLFOC>>> GetQualityCLFOC()
        {
            return await _context.QualityCLFOC.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLFOC>>> GetQualityCLFOC(string Plant)
        //{
        //    return await _context.QualityCLFOC.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLFOC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLFOC>> GetCLFOC(int id)
        {
            var obj = await _context.QualityCLFOC.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLFOC/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLFOC(int id, CLFOC obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
            obj.Modified = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLFOCExists(id))
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

        // POST: api/CLFOC
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLFOC>> PostCLFOC(CLFOC obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLFOC.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLFOC", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLFOC/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLFOC>> DeleteCLFOC(int id)
        {
            var obj = await _context.QualityCLFOC.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLFOC.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLFOCExists(int id)
        {
            return _context.QualityCLFOC.Any(e => e.Id == id);
        }
    }
}
