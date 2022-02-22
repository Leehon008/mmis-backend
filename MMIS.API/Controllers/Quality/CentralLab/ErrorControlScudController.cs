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


    public class ErrorControlScudController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ErrorControlScudController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ErrorControlScud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorControlScud>>> GetQualityErrorControlScud()
        {
            return await _context.QualityErrorControlScud.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ErrorControlScud>>> GetQualityErrorControlScud(string Plant)
        //{
        //    return await _context.QualityErrorControlScud.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/ErrorControlScud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorControlScud>> GetErrorControlScud(int id)
        {
            var obj = await _context.QualityErrorControlScud.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/ErrorControlScud/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorControlScud(int id, ErrorControlScud obj)
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
                if (!ErrorControlScudExists(id))
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

        // POST: api/ErrorControlScud
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ErrorControlScud>> PostErrorControlScud(ErrorControlScud obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityErrorControlScud.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorControlScud", new { id = obj.Id }, obj);
        }

        // DELETE: api/ErrorControlScud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorControlScud>> DeleteErrorControlScud(int id)
        {
            var obj = await _context.QualityErrorControlScud.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityErrorControlScud.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool ErrorControlScudExists(int id)
        {
            return _context.QualityErrorControlScud.Any(e => e.Id == id);
        }
    }
}
