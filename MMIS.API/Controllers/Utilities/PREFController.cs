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

    public class PREFController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PREFController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PREF
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PREF>>> Get()
        //{
        //    return await _context.UtilitiesPREF.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PREF>>> GetList(string Plant)
        {
            return await _context.UtilitiesPREF.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/PREF/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PREF>> Get(int id)
        {
            var obj = await _context.UtilitiesPREF.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/PREF/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PREF obj)
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


            foreach (var navigationProperty in obj.HourlyCoolings.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.UtilitiesPREF.Find(obj.Id)
                        .HourlyCoolings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            //_context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PREFExists(id))
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

        // POST: api/PREF
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PREF>> Post(PREF obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.UtilitiesPREF.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/PREF/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PREF>> Delete(int id)
        {
            var obj = await _context.UtilitiesPREF.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.UtilitiesPREF.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool PREFExists(int id)
        {
            return _context.UtilitiesPREF.Any(e => e.Id == id);
        }
    }
}
