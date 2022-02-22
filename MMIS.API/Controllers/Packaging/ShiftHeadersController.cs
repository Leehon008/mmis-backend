using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;

namespace MMIS.API.Controllers.Packaging
{

    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class ShiftHeadersController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ShiftHeadersController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/ShiftHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftHeader>>> GetShiftHeader()
        {
            return await _context.ShiftHeader.ToListAsync();
        }

        // GET: api/ShiftHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftHeader>> GetShiftHeader(int id)
        {
            var shiftHeader = await _context.ShiftHeader.FindAsync(id);

            if (shiftHeader == null)
            {
                return NotFound();
            }

            return shiftHeader;
        }
        [HttpGet("GetShiftByRange/{Plant}/{moduleId}/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<ShiftHeader>>> GetShiftByRange(string Plant, string moduleId,DateTime startDate,DateTime endDate)
        {
            //_context.
            return await _context.ShiftHeader.Where(m => m.PlantId.Contains(Plant) && m.ShiftGroupId == moduleId && m.StatusId != 3 && m.ShiftStartDate >= startDate && m.ShiftStartDate <= endDate).OrderByDescending(m => m.Id).ToListAsync();
        }

        [HttpGet("{Plant}/{moduleId}")]
        public async Task<ActionResult<IEnumerable<ShiftHeader>>> GetShiftHeader(string Plant, string moduleId)
        {
            //_context.
            return await _context.ShiftHeader.Where(m => m.PlantId.Contains(Plant) && m.ShiftGroupId == moduleId && m.StatusId != 3).OrderByDescending(m => m.Id).ToListAsync();
        }

        [HttpGet("{Plant}/{moduleId}/{shiftname}")]
        public async Task<ActionResult<ShiftHeader>> GetShiftHeader(string Plant, string moduleId, string shiftname)
        {
            //_context.
            return await _context.ShiftHeader.Where(m => m.PlantId.Contains(Plant) && m.ShiftGroupId == moduleId && m.ShiftName == shiftname && m.StatusId != 3).OrderByDescending(m => m.Id).FirstOrDefaultAsync();
        }


        // PUT: api/ShiftHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftHeader(int id, ShiftHeader shiftHeader)
        {
            if (id != shiftHeader.Id)
            {
                return BadRequest();
            }

            shiftHeader.ModifiedOn = DateTime.Now;
          
            _context.Attach(shiftHeader);

            var entry = _context.Entry(shiftHeader);
            entry.State = EntityState.Modified;
            entry.Property(e => e.ShiftNo).IsModified = false;
      
            foreach (var navigationProperty in shiftHeader.shiftMeeting.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.ShiftHeader.Find(shiftHeader.Id)
                        .shiftMeeting.Where(m => m.Id == ((-1) * navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in shiftHeader.shifAttendence.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.ShiftHeader.Find(shiftHeader.Id)
                        .shifAttendence.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftHeaderExists(id))
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

        // POST: api/ShiftHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShiftHeader>> PostShiftHeader(ShiftHeader shiftHeader)
        {
            shiftHeader.CreatedOn = DateTime.Now;
            shiftHeader.ModifiedOn = DateTime.Now;
            int interval = 2;
            do
            {
                DateTime start = shiftHeader.ShiftStartDate.AddHours((interval - 1));
                DateTime end = shiftHeader.ShiftStartDate.AddHours(interval) < shiftHeader.ShiftEndDate ? shiftHeader.ShiftStartDate.AddHours(interval) : shiftHeader.ShiftEndDate;
                int length = (int)end.Subtract(start).TotalMinutes;
                shiftHeader.LWIntervals.Add(new LWInterval
                {
                    Interval = interval,
                    Start = start,
                    End = end,
                    Length = length
                });
            } while (shiftHeader.ShiftStartDate.AddHours(interval++) < shiftHeader.ShiftEndDate);


            _context.ShiftHeader.Add(shiftHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShiftHeader", new { id = shiftHeader.Id }, shiftHeader);
        }

        // DELETE: api/ShiftHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftHeader>> DeleteShiftHeader(int id)
        {
            var shiftHeader = await _context.ShiftHeader.FindAsync(id);
            if (shiftHeader == null)
            {
                return NotFound();
            }

            _context.Attach(shiftHeader);

            var entry = _context.Entry(shiftHeader);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in shiftHeader.shiftMeeting.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.ShiftHeader.Find(shiftHeader.Id)
                    .shiftMeeting.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in shiftHeader.shifAttendence.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.ShiftHeader.Find(shiftHeader.Id)
                    .shifAttendence.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in shiftHeader.LWIntervals.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.ShiftHeader.Find(shiftHeader.Id)
                    .LWIntervals.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftHeaderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return shiftHeader;
        }

        private bool ShiftHeaderExists(int id)
        {
            return _context.ShiftHeader.Any(e => e.Id == id);
        }
    }
}
