using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.UtilitiesEng.Entities;

namespace MMIS.API.Controllers.UtilitiesEng
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CoalUsageController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CoalUsageController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CoalUsage
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CoalUsage>>> Get()
        //{
        //    return await _context.UtilitiesMeter.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoalUsage>>> GetList(string Plant)
        {
            return await _context.UtilitiesCoalUsage.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }


        // GET: api/CoalUsage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoalUsage>> Get(int id)
        {
            var obj = await _context.UtilitiesCoalUsage.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CoalUsage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CoalUsage obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;
            //_context.Entry(obj).State = EntityState.Modified;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            //_context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeterExists(id))
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

        // POST: api/CoalUsage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CoalUsage>> Post(CoalUsage obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.UtilitiesCoalUsage.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/CoalUsage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoalUsage>> Delete(int id)
        {
            var obj = await _context.UtilitiesCoalUsage.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.UtilitiesCoalUsage.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool MeterExists(int id)
        {
            return _context.UtilitiesCoalUsage.Any(e => e.Id == id);
        }
    }
}
