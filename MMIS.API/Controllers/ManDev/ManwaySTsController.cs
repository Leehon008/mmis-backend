using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.ManDev.Entities;

namespace MMIS.API.Controllers.ManDev
{
    [Route("api/[controller]")]
    [ApiController]
 //   [Microsoft.AspNetCore.Authorization.Authorize]

    public class ManwaySTsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ManwaySTsController(MMISDbContext context)
        {
            _context = context;
        }

        //GET: api/ManWaySTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManWaySTs>>> GetManWaySTs()
        {
            return await _context.ManWayStopThinks.ToListAsync();
        }

        [HttpGet("GetSTById/{id}")]
        public async Task<ActionResult<ManWaySTHeader>> GetSTById(int id)
        {
            var obj = await _context.ManWaySTHeader.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        [HttpGet("GetSTByPlant/{Plant}/{sttype}")]
        public async Task<ActionResult<IEnumerable<ManWaySTHeader>>> GetSTByPlant(string Plant,string sttype)
        {
            return await _context.ManWaySTHeader.Where(m =>m.Plant.Contains(Plant) && m.STType.Equals(sttype)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/ManWaySTs/5
        [HttpGet("{sttype}")]
        public async Task<ActionResult<IEnumerable<ManWaySTs>>> GetManWaySTs(string sttype)
        {
            var obj = await _context.ManWayStopThinks.Where(x=>x.STType.ToLower().Equals(sttype.ToLower())).ToListAsync();

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/ManWaySTs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManWaySTs(int id, ManWaySTHeader obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;

            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            
            foreach (var navigationProperty in obj.MWSTsLineItems.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var mid = navigationProperty.Id * (-1);
                    var entityEntry = _context.Entry(_context.ManWaySTHeader.Find(obj.Id)
                        .MWSTsLineItems.Where(m => m.Id == mid).FirstOrDefault());
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
                if (!ManWaySTHeaderExists(id))
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

        // POST: api/ManWaySTs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<List<ManWaySTHeader>>> PostManWaySTs(ManWaySTHeader obj)
        {
           
                _context.ManWaySTHeader.Add(obj);
                await _context.SaveChangesAsync();
            
     

            return CreatedAtAction("GetManWaySTs", new {obj.Id, obj });
        }

        // DELETE: api/ManWaySTs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManWaySTHeader>> DeleteManWaySTs(int id)
        {
            var obj = await _context.ManWaySTHeader.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in obj.MWSTsLineItems.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.ManWaySTHeader.Find(obj.Id)
                    .MWSTsLineItems.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            var entityEntry1 = _context.Entry(_context.ManWaySTHeader.Find(obj.Id)
                   .MWSTsEmpowerment);
            entityEntry1.State = EntityState.Deleted;
            


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManWaySTHeaderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return obj;

        }

        private bool ManWaySTHeaderExists(int id)
        {
            return _context.ManWaySTHeader.Any(e => e.Id == id);
        }

        private bool ManWaySTsExists(int id)
        {
            return _context.ManWayStopThinks.Any(e => e.Id == id);
        }
    }
}
