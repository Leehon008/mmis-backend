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
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class DeviationsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public DeviationsController(MMISDbContext context)
        {
            _context = context;
        }

        //GET: api/Deviation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deviation>>> GetDeviation()
        {
            return await _context.MandevDeviation.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Deviation>>> GetDeviation(string Plant)
        //{
        //    return await _context.MandevDeviation.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/Deviation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deviation>> GetDeviation(int id)
        {
            var obj = await _context.MandevDeviation.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Deviation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviation(int id, Deviation obj)
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

            foreach (var navigationProperty in obj.Parameters.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                        .Parameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.CorrectiveActions.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                        .CorrectiveActions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.TechnicalApproval.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                        .TechnicalApproval.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.Approvals.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                        .Approvals.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!DeviationExists(id))
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

        // POST: api/Deviation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Deviation>> PostDeviation(Deviation obj)
        {
            obj.Modified = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MandevDeviation.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeviation", new { id = obj.Id }, obj);
        }

        // DELETE: api/Deviation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deviation>> DeleteDeviation(int id)
        {
            var obj = await _context.MandevDeviation.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            //_context.MandevDeviation.Remove(obj);
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Parameters)
            {
                var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                    .Parameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in obj.CorrectiveActions)
            {
                var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                    .CorrectiveActions.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in obj.TechnicalApproval)
            {
                var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                    .TechnicalApproval.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in obj.Approvals)
            {
                var entityEntry = _context.Entry(_context.MandevDeviation.Find(obj.Id)
                    .Approvals.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return obj;
        }

        private bool DeviationExists(int id)
        {
            return _context.MandevDeviation.Any(e => e.Id == id);
        }
    }
}
