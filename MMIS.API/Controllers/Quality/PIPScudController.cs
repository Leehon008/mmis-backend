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



    public class PIPScudController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PIPScudController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIP
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PackagingInProgressScud>>> GetQualityPIPScud()
        //{
        //    return await _context.QualityPIPScud.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackagingInProgressScud>>> GetQualityPIPScud(string Plant)
        {
            return await _context.QualityPIPScud.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfPacking).ToListAsync();
        }

        // GET: api/PIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackagingInProgressScud>> GetPackagingInProgressScud(int id)
        {
            var packagingInProgress = await _context.QualityPIPScud.FindAsync(id);

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
        public async Task<IActionResult> PutPackagingInProgressScud(int id, PackagingInProgressScud packagingInProgress)
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

            foreach (var navigationProperty in packagingInProgress.Brews.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                        .Brews.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in packagingInProgress.Materials.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                        .Materials.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }


            //foreach (var navigationProperty in packagingInProgress.BadClosures.OrderByDescending(m => m.Id))
            //{
            //    bool delete = navigationProperty.Id < 0 ? true : false;
            //    if (delete)
            //    {
            //        var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
            //            .BadClosures.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
            //        entityEntry.State = EntityState.Deleted;
            //    }
            //    else
            //    {
            //        var entityEntry = _context.Entry(navigationProperty);
            //        entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
            //    }
            //}


            foreach (var navigationProperty in packagingInProgress.DamagedBottles.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                        .DamagedBottles.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!PackagingInProgressScudExists(id))
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
        public async Task<ActionResult<PackagingInProgressScud>> PostPackagingInProgressScud(PackagingInProgressScud packagingInProgress)
        {
            packagingInProgress.Created = DateTime.Now;
            packagingInProgress.Modified = packagingInProgress.Created;
            _context.QualityPIPScud.Add(packagingInProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackagingInProgressScud", new { id = packagingInProgress.Id }, packagingInProgress);
        }

        // DELETE: api/PIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackagingInProgressScud>> DeletePackagingInProgressScud(int id)
        {
            var packagingInProgress = await _context.QualityPIPScud.FindAsync(id);
            if (packagingInProgress == null)
            {
                return NotFound();
            }

            _context.Attach(packagingInProgress);

            var entry = _context.Entry(packagingInProgress);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in packagingInProgress.DamagedBottles)
            {
                var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                    .DamagedBottles.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in packagingInProgress.Brews)
            {
                var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                    .Brews.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            foreach (var navigationProperty in packagingInProgress.Materials)
            {
                var entityEntry = _context.Entry(_context.QualityPIPScud.Find(packagingInProgress.Id)
                    .Materials.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            //            _context.QualityPIPScud.Remove(packagingInProgress);
            await _context.SaveChangesAsync();

            return packagingInProgress;
        }

        private bool PackagingInProgressScudExists(int id)
        {
            return _context.QualityPIPScud.Any(e => e.Id == id);
        }
    }
}
