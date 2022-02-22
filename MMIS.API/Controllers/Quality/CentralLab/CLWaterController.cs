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


    public class CLWaterController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLWaterController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLWater
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLWater>>> GetQualityCLWater()
        {
            return await _context.QualityCLWater.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLWater>>> GetQualityCLWater(string Plant)
        //{
        //    return await _context.QualityCLWater.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLWater/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLWater>> GetCLWater(int id)
        {
            var obj = await _context.QualityCLWater.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLWater/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLWater(int id, CLWater obj)
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
                if (!CLWaterExists(id))
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

        // POST: api/CLWater
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLWater>> PostCLWater(CLWater obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLWater.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLWater", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLWater/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLWater>> DeleteCLWater(int id)
        {
            var obj = await _context.QualityCLWater.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLWater.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLWaterExists(int id)
        {
            return _context.QualityCLWater.Any(e => e.Id == id);
        }
    }
}
