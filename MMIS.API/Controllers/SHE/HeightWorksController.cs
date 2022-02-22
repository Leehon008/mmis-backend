using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

using Microsoft.AspNetCore.Authorization;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class HeightWorksController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public HeightWorksController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/HeightWorks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeightWork>>> GetHeightWork()
        {
            return await _context.HeightWork.ToListAsync();
        }

        // GET: api/HeightWorks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeightWork>> GetHeightWork(int id)
        {
            var heightWork = await _context.HeightWork.FindAsync(id);

            if (heightWork == null)
            {
                return NotFound();
            }

            return heightWork;
        }

        // PUT: api/HeightWorks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeightWork(int id, HeightWork heightWork)
        {
            if (id != heightWork.Id)
            {
                return BadRequest();
            }
            heightWork.DateModified = DateTime.Now;
            _context.Entry(heightWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeightWorkExists(id))
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

        // POST: api/HeightWorks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HeightWork>> PostHeightWork(HeightWork heightWork)
        {
            heightWork.DateModified = DateTime.Now;
            heightWork.DateCreated = DateTime.Now;
            _context.HeightWork.Add(heightWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeightWork", new { id = heightWork.Id }, heightWork);
        }

        // DELETE: api/HeightWorks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HeightWork>> DeleteHeightWork(int id)
        {
            var heightWork = await _context.HeightWork.FindAsync(id);
            if (heightWork == null)
            {
                return NotFound();
            }

            _context.HeightWork.Remove(heightWork);
            await _context.SaveChangesAsync();

            return heightWork;
        }

        private bool HeightWorkExists(int id)
        {
            return _context.HeightWork.Any(e => e.Id == id);
        }
    }
}
