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



    public class MaltingTranferController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaltingTranferController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MaltingsTranfer
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltingTranfer>>> GetMaltingsKilning()
        //{
        //    return await _context.MaltingsTransfer.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltingTranfer>>> GetMaltingsKilning(string Plant)
        {
            return await _context.MaltingsTransfer.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Created).ToListAsync();
        }

        // GET: api/MaltingsTranfer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltingTranfer>> GetKilning(int id)
        {
            var obj = await _context.MaltingsTransfer.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/MaltingsTranfer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKilning(int id, MaltingTranfer obj)
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

        // POST: api/MaltingsTranfer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltingTranfer>> PostKilning(MaltingTranfer obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsTransfer.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKilning", new { id = obj.Id }, obj);
        }

        // DELETE: api/MaltingsTranfer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltingTranfer>> DeleteKilning(int id)
        {
            var obj = await _context.MaltingsTransfer.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsTransfer.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool KilningExists(int id)
        {
            return _context.MaltingsTransfer.Any(e => e.Id == id);
        }
    }
}
