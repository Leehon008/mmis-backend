using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Maltings.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]



    public class MaltingsDispatchController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltingsDispatchController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltingsDispatch
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltDispatch>>> GetMaltingsKilning()
        //{
        //    return await _context.MaltingsDispatch.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltDispatch>>> GetMaltingsKilning(string Plant)
        {
            return await _context.MaltingsDispatch.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Created).ToListAsync();
        }

        // GET: api/MaltingsDispatch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltDispatch>> GetKilning(int id)
        {
            var obj = await _context.MaltingsDispatch.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/MaltingsDispatch/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKilning(int id, MaltDispatch obj)
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
                if (!KilningExists(id))
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

        // POST: api/MaltingsDispatch
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltDispatch>> PostKilning(MaltDispatch obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsDispatch.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKilning", new { id = obj.Id }, obj);
        }

        // DELETE: api/MaltingsDispatch/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltDispatch>> DeleteKilning(int id)
        {
            var obj = await _context.MaltingsDispatch.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsDispatch.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool KilningExists(int id)
        {
            return _context.MaltingsDispatch.Any(e => e.Id == id);
        }
    }
}
