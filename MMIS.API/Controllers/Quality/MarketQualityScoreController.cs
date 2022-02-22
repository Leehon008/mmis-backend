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

    public class MarketQualityScoreController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MarketQualityScoreController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MarketQualityScores
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MarketQualityScore>>> GetQualityMarketQualityScore()
        //{
        //    return await _context.QualityMarketQualityScore.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketQualityScore>>> GetQualityMarketQualityScore(string Plant)
        {
            return await _context.QualityMarketQualityScore.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/MarketQualityScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketQualityScore>> GetMarketQualityScore(int id)
        {
            var obj = await _context.QualityMarketQualityScore.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/MarketQualityScores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketQualityScore(int id, MarketQualityScore obj)
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


            foreach (var navigationProperty in obj.CompetitorProducts.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityMarketQualityScore.Find(obj.Id)
                        .CompetitorProducts.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.MQSScud.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityMarketQualityScore.Find(obj.Id)
                        .MQSScud.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in obj.MQSSuper.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityMarketQualityScore.Find(obj.Id)
                        .MQSSuper.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!MarketQualityScoreExists(id))
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

        // POST: api/MarketQualityScores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketQualityScore>> PostMarketQualityScore(MarketQualityScore obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityMarketQualityScore.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketQualityScore", new { id = obj.Id }, obj);
        }

        // DELETE: api/MarketQualityScores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketQualityScore>> DeleteMarketQualityScore(int id)
        {
            var obj = await _context.QualityMarketQualityScore.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityMarketQualityScore.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool MarketQualityScoreExists(int id)
        {
            return _context.QualityMarketQualityScore.Any(e => e.Id == id);
        }
    }
}
