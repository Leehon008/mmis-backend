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


    public class CLMicrosController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLMicrosController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLMicros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLMicros>>> GetQualityCLMicros()
        {
            return await _context.QualityCLMicros.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLMicros>>> GetQualityCLMicros(string Plant)
        //{
        //    return await _context.QualityCLMicros.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLMicros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLMicros>> GetCLMicros(int id)
        {
            var obj = await _context.QualityCLMicros.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLMicros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLMicros(int id, CLMicros obj)
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
                if (!CLMicrosExists(id))
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

        // POST: api/CLMicros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLMicros>> PostCLMicros(CLMicros obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLMicros.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLMicros", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLMicros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLMicros>> DeleteCLMicros(int id)
        {
            var obj = await _context.QualityCLMicros.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLMicros.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLMicrosExists(int id)
        {
            return _context.QualityCLMicros.Any(e => e.Id == id);
        }
    }
}
