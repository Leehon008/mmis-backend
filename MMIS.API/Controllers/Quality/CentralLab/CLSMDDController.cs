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


    public class CLSMDDController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLSMDDController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLSMDD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLSMDD>>> GetQualityCLSMDD()
        {
            return await _context.QualityCLSMDD.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLSMDD>>> GetQualityCLSMDD(string Plant)
        //{
        //    return await _context.QualityCLSMDD.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLSMDD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLSMDD>> GetCLSMDD(int id)
        {
            var obj = await _context.QualityCLSMDD.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLSMDD/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLSMDD(int id, CLSMDD obj)
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
                if (!CLSMDDExists(id))
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

        // POST: api/CLSMDD
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLSMDD>> PostCLSMDD(CLSMDD obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLSMDD.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLSMDD", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLSMDD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLSMDD>> DeleteCLSMDD(int id)
        {
            var obj = await _context.QualityCLSMDD.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLSMDD.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLSMDDExists(int id)
        {
            return _context.QualityCLSMDD.Any(e => e.Id == id);
        }
    }
}
