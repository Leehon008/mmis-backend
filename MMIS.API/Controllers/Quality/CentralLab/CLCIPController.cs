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


    public class CLCIPController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLCIPController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLCIP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLCIP>>> GetQualityCLCIP()
        {
            return await _context.QualityCLCIP.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLCIP>>> GetQualityCLCIP(string Plant)
        //{
        //    return await _context.QualityCLCIP.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLCIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLCIP>> GetCLCIP(int id)
        {
            var obj = await _context.QualityCLCIP.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLCIP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLCIP(int id, CLCIP obj)
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
                if (!CLCIPExists(id))
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

        // POST: api/CLCIP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLCIP>> PostCLCIP(CLCIP obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLCIP.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLCIP", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLCIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLCIP>> DeleteCLCIP(int id)
        {
            var obj = await _context.QualityCLCIP.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLCIP.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLCIPExists(int id)
        {
            return _context.QualityCLCIP.Any(e => e.Id == id);
        }
    }
}
