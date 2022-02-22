using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.ManDev.Entities;

namespace MMIS.API.Controllers.Maltings
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

 

    public class PlantRankingController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IMapper _mapper;

        public PlantRankingController(MMISDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET: api/PlantRanking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantRanking>>> Getlist()
        {
            return await _context.MandevPlantRanking.ToListAsync();
        }


        [HttpGet("{Plant}")]
        public async Task<ActionResult<PlantRanking>> GetMaster(string Plant)
        {
            if(Plant != null && _context.MandevPlantRankingMaster.Where(m => m.Plant.Contains(Plant)).Any())
            {
                PlantRanking obj = _mapper.Map<PlantRanking>(await _context.MandevPlantRankingMaster.Where(m => m.Plant.Contains(Plant)).FirstOrDefaultAsync());
                return obj;
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/PlantRanking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantRanking>> GetDetails(int id)
        {
            var obj = await _context.MandevPlantRanking.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/PlantRanking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PlantRanking obj)
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
                    var entityEntry = _context.Entry(_context.MandevPlantRanking.Find(obj.Id)
                        .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                    foreach (var nestedNavigationProperty in navigationProperty.KPIs.OrderByDescending(m => m.Id))
                    {
                        var nestedEntityEntry = _context.Entry(_context.MandevPlantRanking.Find(obj.Id)
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
                            var nestedEntityEntry = _context.Entry(_context.MandevPlantRanking.Find(obj.Id)
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
                if (!PlantRankingExists(id))
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

        // POST: api/PlantRanking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Plant}")]
        public async Task<ActionResult<PlantRanking>> Create(string Plant, PlantRanking obj)
        {
            if (Plant == null || !_context.MandevPlantRanking.Where(m => m.Plant.Contains(Plant)).Any())
            {
                return NotFound();
            }
            obj = _mapper.Map<PlantRanking>(await _context.MandevPlantRanking.Where(m => m.Plant.Contains(Plant)).FirstOrDefaultAsync());
            obj.Created = DateTime.Now;
            obj.Modified = DateTime.Now;
            //_context.MandevPlantRanking.Add(obj);

            _context.Entry(obj).State = EntityState.Added;

            foreach (var navigationProperty in obj.Baskets)
            {
                var entityEntry = _context.Entry(navigationProperty);
                navigationProperty.Id = 0;
                entityEntry.State = EntityState.Added;
                foreach (var nestedNavigationProperty in navigationProperty.KPIs)
                {
                    var nestedEntityEntry = _context.Entry(nestedNavigationProperty);
                    nestedNavigationProperty.Id = 0;
                    nestedEntityEntry.State = EntityState.Added;
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetails", new { id = obj.Id }, obj);
        }

        // DELETE: api/PlantRanking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantRanking>> Delete(int id)
        {
            var obj = await _context.MandevPlantRanking.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Entry(obj).State = EntityState.Deleted;

            foreach (var navigationProperty in obj.Baskets.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.MandevPlantRanking.Find(obj.Id)
                    .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
                foreach (var nestedNavigationProperty in navigationProperty.KPIs.OrderByDescending(m => m.Id))
                {
                    var nestedEntityEntry = _context.Entry(_context.MandevPlantRanking.Find(obj.Id)
                        .Baskets.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                        .KPIs.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                    nestedEntityEntry.State = EntityState.Deleted;
                }
            }

            //_context.MandevPlantRanking.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool PlantRankingExists(int id)
        {
            return _context.MandevPlantRanking.Any(e => e.Id == id);
        }
    }
}
