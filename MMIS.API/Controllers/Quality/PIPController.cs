using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]



    public class PIPController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PIPController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIP
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PackagingInProgress>>> GetQualityPIP()
        //{
        //    return await _context.QualityPIP.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackagingInProgress>>> GetQualityPIP(string Plant)
        {
            return await _context.QualityPIP.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfPacking).ToListAsync();
        }

        // GET: api/PIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackagingInProgress>> GetPackagingInProgress(int id)
        {
            var packagingInProgress = await _context.QualityPIP.FindAsync(id);

            if (packagingInProgress == null)
            {
                return NotFound();
            }

            return packagingInProgress;
        }

        // PUT: api/PIP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackagingInProgress(int id, PackagingInProgress packagingInProgress)
        {
            if (id != packagingInProgress.Id)
            {
                return BadRequest();
            }
            packagingInProgress.Modified = DateTime.Now;
            //_context.Entry(packagingInProgress).State = EntityState.Modified;
            _context.Attach(packagingInProgress);

            var entry = _context.Entry(packagingInProgress);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in packagingInProgress.Brews.OrderByDescending(m=>m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityPIPBrew.Find(Math.Abs(navigationProperty.Id)));
                    entityEntry.State = EntityState.Deleted;
                }
                else if (navigationProperty.Id == 0)
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Added;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Modified;
                }
            }

            foreach (var navigationProperty in packagingInProgress.Materials.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                navigationProperty.Id = Math.Abs(navigationProperty.Id);
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityPIPMaterial.Find(Math.Abs(navigationProperty.Id)));
                    entityEntry.State = EntityState.Deleted;
                }
                else if (navigationProperty.Id == 0)
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Added;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Modified;
                }//entityEntry.Property(navProp => navProp.Id).IsModified = false;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagingInProgressExists(id))
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

        // POST: api/PIP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PackagingInProgress>> PostPackagingInProgress(PackagingInProgress packagingInProgress)
        {
            packagingInProgress.Created = DateTime.Now;
            packagingInProgress.Modified = packagingInProgress.Created;
            _context.QualityPIP.Add(packagingInProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackagingInProgress", new { id = packagingInProgress.Id }, packagingInProgress);
        }

        // DELETE: api/PIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackagingInProgress>> DeletePackagingInProgress(int id)
        {
            var packagingInProgress = await _context.QualityPIP.FindAsync(id);
            if (packagingInProgress == null)
            {
                return NotFound();
            }

            _context.Attach(packagingInProgress);

            var entry = _context.Entry(packagingInProgress);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in packagingInProgress.Brews)
            {
                var entityEntry = _context.Entry(_context.QualityPIPBrew.Find(Math.Abs(navigationProperty.Id)));
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in packagingInProgress.Materials)
            {
                var entityEntry = _context.Entry(_context.QualityPIPMaterial.Find(Math.Abs(navigationProperty.Id)));
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return packagingInProgress;
        }

        private bool PackagingInProgressExists(int id)
        {
            return _context.QualityPIP.Any(e => e.Id == id);
        }
    }
}
