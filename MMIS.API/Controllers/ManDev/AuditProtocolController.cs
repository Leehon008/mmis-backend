using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.ManDev.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]



    public class AuditProtocolController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public AuditProtocolController(MMISDbContext context)
        {
            _context = context;
        }

        //GET: api/AuditProtocol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditProtocol>>> GetAuditProtocol()
        {
            return await _context.MandevAuditProtocol.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AuditProtocol>>> GetAuditProtocol(string Plant)
        //{
        //    return await _context.MandevAuditProtocol.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/AuditProtocol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditProtocol>> GetAuditProtocol(int id)
        {
            var obj = await _context.MandevAuditProtocol.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/AuditProtocol/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditProtocol(int id, AuditProtocol obj)
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

            foreach (var navigationProperty in obj.Scopings.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevAuditProtocol.Find(obj.Id)
                        .Scopings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!AuditProtocolExists(id))
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

        // POST: api/AuditProtocol
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuditProtocol>> PostAuditProtocol(AuditProtocol obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MandevAuditProtocol.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditProtocol", new { id = obj.Id }, obj);
        }

        // DELETE: api/AuditProtocol/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditProtocol>> DeleteAuditProtocol(int id)
        {
            var obj = await _context.MandevAuditProtocol.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            //_context.MandevAuditProtocol.Remove(obj);
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Scopings)
            {
                var entityEntry = _context.Entry(_context.MandevAuditProtocol.Find(obj.Id)
                    .Scopings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return obj;
        }

        private bool AuditProtocolExists(int id)
        {
            return _context.MandevAuditProtocol.Any(e => e.Id == id);
        }
    }
}
