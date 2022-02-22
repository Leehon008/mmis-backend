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



    public class MaintenanceController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MaintenanceController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Maintenance
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaltingsMaintenance()
        //{
        //    return await _context.MaltingsMaintenance.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaltingsMaintenance(string Plant)
        {
            return await _context.MaltingsMaintenance.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Maintenance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> GetMaintenance(int id)
        {
            var obj = await _context.MaltingsMaintenance.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Maintenance/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenance(int id, Maintenance obj)
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
                if (!MaintenanceExists(id))
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

        // POST: api/Maintenance
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Maintenance>> PostMaintenance(Maintenance obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MaltingsMaintenance.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenance", new { id = obj.Id }, obj);
        }

        // DELETE: api/Maintenance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maintenance>> DeleteMaintenance(int id)
        {
            var obj = await _context.MaltingsMaintenance.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MaltingsMaintenance.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool MaintenanceExists(int id)
        {
            return _context.MaltingsMaintenance.Any(e => e.Id == id);
        }
    }
}
