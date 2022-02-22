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


    public class ErrorControlSuperController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ErrorControlSuperController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ErrorControlSuper
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorControlSuper>>> GetQualityErrorControlSuper()
        {
            return await _context.QualityErrorControlSuper.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ErrorControlSuper>>> GetQualityErrorControlSuper(string Plant)
        //{
        //    return await _context.QualityErrorControlSuper.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/ErrorControlSuper/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorControlSuper>> GetErrorControlSuper(int id)
        {
            var obj = await _context.QualityErrorControlSuper.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/ErrorControlSuper/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorControlSuper(int id, ErrorControlSuper obj)
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
                if (!ErrorControlSuperExists(id))
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

        // POST: api/ErrorControlSuper
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ErrorControlSuper>> PostErrorControlSuper(ErrorControlSuper obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityErrorControlSuper.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorControlSuper", new { id = obj.Id }, obj);
        }

        // DELETE: api/ErrorControlSuper/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorControlSuper>> DeleteErrorControlSuper(int id)
        {
            var obj = await _context.QualityErrorControlSuper.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityErrorControlSuper.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool ErrorControlSuperExists(int id)
        {
            return _context.QualityErrorControlSuper.Any(e => e.Id == id);
        }
    }
}
