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


    public class CLEAController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLEAController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLEA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLEA>>> GetQualityCLEA()
        {
            return await _context.QualityCLEA.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLEA>>> GetQualityCLEA(string Plant)
        //{
        //    return await _context.QualityCLEA.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLEA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLEA>> GetCLEA(int id)
        {
            var obj = await _context.QualityCLEA.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLEA/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLEA(int id, CLEA obj)
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
                if (!CLEAExists(id))
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

        // POST: api/CLEA
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLEA>> PostCLEA(CLEA obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLEA.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLEA", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLEA/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLEA>> DeleteCLEA(int id)
        {
            var obj = await _context.QualityCLEA.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLEA.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLEAExists(int id)
        {
            return _context.QualityCLEA.Any(e => e.Id == id);
        }
    }
}
