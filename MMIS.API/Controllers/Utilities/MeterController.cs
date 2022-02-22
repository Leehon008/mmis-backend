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

    public class MeterController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MeterController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Meter
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Meter>>> Get()
        //{
        //    return await _context.UtilitiesMeter.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meter>>> GetList(string Plant)
        {
            return await _context.UtilitiesMeter.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        [HttpGet("{Plant}/{PID}")]
        public async Task<ActionResult<IEnumerable<Meter>>> GetMeters(string Plant, string PID)
        {
            return await _context.UtilitiesMeter.Where(m => m.Plant.Contains(Plant) && m.PID.Equals(PID)).ToListAsync();
        }

        [HttpGet("{Plant}/{PID}/{Frequency}")]
        public async Task<ActionResult<IEnumerable<Meter>>> GetMeters(string Plant, string PID, string Frequency)
        {
            return await _context.UtilitiesMeter.Where(m => m.Plant.Contains(Plant) && m.PID.Equals(PID) && m.Frequency.Equals(Frequency)).ToListAsync();
        }

        [HttpGet("{Plant}/{PID}/{Level}")]
        public async Task<ActionResult<IEnumerable<Meter>>> GetFeeds(string Plant, string PID, int Level)
        {
            if (Level <= 1)
                return (new List<Meter>());
            return await _context.UtilitiesMeter.Where(m => m.Plant.Contains(Plant) && m.PID.Equals(PID) && m.Level == Level - 1).ToListAsync();
        }

        [HttpGet("{Plant}/{PID}")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits(string Plant, string PID)
        {
            return await _context.UtilitiesUnits.Where(m => m.Plant.Contains(Plant) && m.PID.Equals(PID)).ToListAsync();
        }

        private int NextId(Meter meter)
        {
            if(_context.UtilitiesMeter.Where(m => m.Plant.Contains(meter.Plant) && m.PID.Equals(meter.PID) && m.Level.Equals(meter.Level)).Any())
            {
                Meter m = _context.UtilitiesMeter.Where(m => m.Plant.Contains(meter.Plant) && m.PID.Equals(meter.PID) && m.Level.Equals(meter.Level)).OrderBy(m => m.Code).LastOrDefault();
                return m.Code.Length > 7? Convert.ToInt32(m.Code.Substring(7, 2)) + 1 : 10; //DIE0800
            }
            else
            {
                return 10;
            }
        }

        // GET: api/Meter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meter>> Get(int id)
        {
            var obj = await _context.UtilitiesMeter.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Meter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Meter obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;
            obj.Feed = obj.Level <= 1 ? "None" : obj.Feed;
            obj.Code = !CodeChange(obj) ? obj.Code : obj.PID.Substring(obj.PID.Length - 3, 3) + obj.Plant.Substring(1, 3) + obj.Level + NextId(obj);
            
            //_context.Entry(obj).State = EntityState.Modified;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

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

        // POST: api/Meter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Meter>> Post(Meter obj)
        {
            obj.Created = DateTime.Now; 
            obj.Modified = obj.Created;
            obj.Feed = obj.Level <= 1 ? "None" : obj.Feed;
            obj.Code = obj.PID.Substring(obj.PID.Length - 3, 3) + obj.Plant.Substring(1, 3) + obj.Level + NextId(obj);
            _context.UtilitiesMeter.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/Meter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meter>> Delete(int id)
        {
            var obj = await _context.UtilitiesMeter.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.UtilitiesMeter.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CodeChange(Meter obj)
        {
            if (!obj.Code.Contains(obj.Plant.Substring(1, 3)))
                return true;
            else if (!obj.Code.Substring(6, 1).Equals(obj.Level))
                return true;
            else if (!obj.Code.Substring(0, 3).Equals(obj.PID.Substring(obj.PID.Length - 3, 3)))
                return true;
            else
                return false;
        }

        private bool MeterExists(int id)
        {
            return _context.UtilitiesMeter.Any(e => e.Id == id);
        }
    }
}
