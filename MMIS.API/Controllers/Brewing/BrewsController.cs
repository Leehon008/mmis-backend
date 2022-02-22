using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Brewing.Entities;

namespace MMIS.API.Controllers.Brewing
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class BrewsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public BrewsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Brews
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Brew>>> GetBrewingBrews()
        //{
        //    return await _context.BrewingBrews.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brew>>> GetBrewingBrews(string Plant)
        {
            return await _context.BrewingBrews.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Brews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brew>> GetBrew(int id)
        {
            var brew = await _context.BrewingBrews.FindAsync(id);

            if (brew == null)
            {
                return NotFound();
            }

            return brew;
        }


        [HttpGet("GetBrewId/{brewId}")]
        public async Task<ActionResult<IEnumerable<Brew>>> GetBrewId(string brewId)
        {
            var obj = await _context.BrewingBrews.Where(m => m.BrewNumber.Equals(brewId)).ToListAsync();

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Brews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrew(int id, Brew brew)
        {
            if (id != brew.Id)
            {
                return BadRequest();
            }

            Brew temp = _context.BrewingBrews.Find(id);
            _context.Entry(temp).State = EntityState.Modified;

            //_context.Remove(temp);

            brew.Modified = DateTime.Now;
            temp.BrewNumber = brew.BrewNumber;
            temp.Plant = brew.Plant;
            temp.Date = brew.Date;
            temp.Shift = brew.Shift;
            temp.MaltPieceNumber = brew.MaltPieceNumber;
            temp.RawMaterialSapWorkOrder = brew.RawMaterialSapWorkOrder;
            temp.WaterSource = brew.WaterSource;
            temp.YeastBatchNumber = brew.YeastBatchNumber;

            //_context.Attach(brew);

            //var entry = _context.Entry(temp);
            //entry.State = EntityState.Modified;
            //_context.Entry(temp).State.Property(e => e.Created).IsModified = false;

            foreach (Stocks s in temp.Stocks)
            {
                if (!brew.Stocks.Where(m => m.Id == s.Id).Any())
                {
                    _context.Entry(s).State = EntityState.Deleted;
                }
                
                else if(brew.Stocks.Where(m => m.Id == s.Id).Any())
                {
                    Stocks stock = brew.Stocks.Where(m => m.Id == s.Id).FirstOrDefault();
                    s.Date = stock.Date;
                    s.Material = stock.Material;
                    s.OpeningStock = stock.OpeningStock;
                    s.ClosingStock = stock.ClosingStock;
                    var entityEntry = _context.Entry(s);
                    entityEntry.State = EntityState.Modified;
                }
            }

            foreach (var navigationProperty in brew.Stocks.Where(m => m.Id == 0))
            {
                temp.Stocks.Add(navigationProperty);
            }

            foreach (var navigationProperty in temp.Stocks.Where(m => m.Id == 0))
            {
                var entityEntry = _context.Entry(navigationProperty);
                entityEntry.State = EntityState.Added;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrewExists(id))
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

        // POST: api/Brews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Brew>> PostBrew(Brew brew)
        {
            brew.Modified = DateTime.Now;
            brew.Created = DateTime.Now;
            _context.BrewingBrews.Add(brew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrew", new { id = brew.Id }, brew);
        }

        // DELETE: api/Brews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brew>> DeleteBrew(int id)
        {
            var brew = await _context.BrewingBrews.FindAsync(id);
            if (brew == null)
            {
                return NotFound();
            }

            _context.BrewingBrews.Remove(brew);
            await _context.SaveChangesAsync();

            return brew;
        }

        private bool BrewExists(int id)
        {
            return _context.BrewingBrews.Any(e => e.Id == id);
        }
    }
}
