using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Deviations.Entities;

namespace MMIS.API.Controllers.Deviations
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class NotificationsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public NotificationsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Notification
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Notification>>> Get()
        //{
        //    return await _context.MandevNotification.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetList(string Plant)
        {
            return await _context.MandevNotification.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Modified).ToListAsync();
        }

        [HttpGet("{Plant}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(string Plant)
        {
            return await _context.MandevNotification.Where(m => m.Plant.Contains(Plant)).ToListAsync();
        }


        // GET: api/Notification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> Get(int id)
        {
            var obj = await _context.MandevNotification.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Notification/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Notification obj)
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
                if (!NotificationExists(id))
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

        // POST: api/Notification
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notification>> Post(Notification obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.MandevNotification.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/Notification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notification>> Delete(int id)
        {
            var obj = await _context.MandevNotification.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.MandevNotification.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool NotificationExists(int id)
        {
            return _context.MandevNotification.Any(e => e.Id == id);
        }
    }
}
