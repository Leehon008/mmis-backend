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


    public class CLUtilitiesController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLUtilitiesController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLUtilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLUtilities>>> GetQualityCLUtilities()
        {
            return await _context.QualityCLUtilities.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLUtilities>>> GetQualityCLUtilities(string Plant)
        //{
        //    return await _context.QualityCLUtilities.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLUtilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLUtilities>> GetCLUtilities(int id)
        {
            var obj = await _context.QualityCLUtilities.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLUtilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLUtilities(int id, CLUtilities obj)
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
                if (!CLUtilitiesExists(id))
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

        // POST: api/CLUtilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLUtilities>> PostCLUtilities(CLUtilities obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLUtilities.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLUtilities", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLUtilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLUtilities>> DeleteCLUtilities(int id)
        {
            var obj = await _context.QualityCLUtilities.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLUtilities.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLUtilitiesExists(int id)
        {
            return _context.QualityCLUtilities.Any(e => e.Id == id);
        }
    }
}
