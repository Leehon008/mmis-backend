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


    public class CLWDDController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLWDDController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLWDD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLWDD>>> GetQualityCLWDD()
        {
            return await _context.QualityCLWDD.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLWDD>>> GetQualityCLWDD(string Plant)
        //{
        //    return await _context.QualityCLWDD.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLWDD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLWDD>> GetCLWDD(int id)
        {
            var obj = await _context.QualityCLWDD.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLWDD/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLWDD(int id, CLWDD obj)
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
                if (!CLWDDExists(id))
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

        // POST: api/CLWDD
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLWDD>> PostCLWDD(CLWDD obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLWDD.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLWDD", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLWDD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLWDD>> DeleteCLWDD(int id)
        {
            var obj = await _context.QualityCLWDD.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLWDD.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLWDDExists(int id)
        {
            return _context.QualityCLWDD.Any(e => e.Id == id);
        }
    }
}
