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



    public class PlantRankingMasterController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PlantRankingMasterController(MMISDbContext context)
        {
            _context = context;
        }

        //GET: api/PlantRankingMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantRankingMaster>>> GetPlantRankingMaster()
        {
            return await _context.MandevPlantRankingMaster.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PlantRankingMaster>>> GetPlantRankingMaster(string Plant)
        //{
        //    return await _context.MandevPlantRankingMaster.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/PlantRankingMaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantRankingMaster>> GetPlantRankingMaster(int id)
        {
            var obj = await _context.MandevPlantRankingMaster.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/PlantRankingMaster/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantRankingMaster(int id, PlantRankingMaster obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
            //_context.Entry(obj).State = EntityState.Modified;

            obj.Modified = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;

            foreach (var navigationProperty in obj.Baskets.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevPlantRankingMaster.Find(obj.Id)
                        .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                    foreach (var nestedNavigationProperty in navigationProperty.KPIs.OrderByDescending(m => m.Id))
                    {
                        var nestedEntityEntry = _context.Entry(_context.MandevPlantRankingMaster.Find(obj.Id)
                            .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                            .KPIs.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                        nestedEntityEntry.State = EntityState.Deleted;
                    }
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                    foreach (var nestedNavigationProperty in navigationProperty.KPIs.OrderByDescending(m => m.Id))
                    {
                        bool nestedDelete = (nestedNavigationProperty.Id < 0) ? true : false;
                        if (nestedDelete)
                        {
                            var nestedEntityEntry = _context.Entry(_context.MandevPlantRankingMaster.Find(obj.Id)
                                .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                                .KPIs.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                            nestedEntityEntry.State = EntityState.Deleted;
                        }
                        else
                        {
                            var nestedEntityEntry = _context.Entry(nestedNavigationProperty);
                            nestedEntityEntry.State = nestedNavigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                        }
                    }
                }
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantRankingMasterExists(id))
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

        // POST: api/PlantRankingMaster
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlantRankingMaster>> PostPlantRankingMaster(PlantRankingMaster obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = DateTime.Now;
            _context.MandevPlantRankingMaster.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantRankingMaster", new { id = obj.Id }, obj);
        }

        // DELETE: api/PlantRankingMaster/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantRankingMaster>> DeletePlantRankingMaster(int id)
        {
            var obj = await _context.MandevPlantRankingMaster.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Entry(obj).State = EntityState.Deleted;

            foreach (var navigationProperty in obj.Baskets.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.MandevPlantRankingMaster.Find(obj.Id)
                    .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
                foreach (var nestedNavigationProperty in navigationProperty.KPIs.OrderByDescending(m => m.Id))
                {
                    var nestedEntityEntry = _context.Entry(_context.MandevPlantRankingMaster.Find(obj.Id)
                        .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                        .KPIs.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                    nestedEntityEntry.State = EntityState.Deleted;
                }
            }

            //_context.MandevPlantRankingMaster.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool PlantRankingMasterExists(int id)
        {
            return _context.MandevPlantRankingMaster.Any(e => e.Id == id);
        }
    }
}
