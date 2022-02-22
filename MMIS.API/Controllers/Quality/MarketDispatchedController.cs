using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.SHE.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;
using MMIS.DomainLayer.Quality.Models;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class MarketDispatchedController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public MarketDispatchedController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/MarketDispatcheds
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MarketDispatched>>> GetMarketDispatcheds()
        //{
        //    return await _context.QualityMarketDispatched.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketDispatched>>> GetMarketDispatcheds(string Plant)
        {
            return await _context.QualityMarketDispatched.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/MarketDispatcheds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarketDispatched>> GetMarketDispatched(int id)
        {
            var marketDispatched = await _context.QualityMarketDispatched.FindAsync(id);

            if (marketDispatched == null)
            {
                return NotFound();
            }

            return marketDispatched;
        }

        // PUT: api/MarketDispatcheds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarketDispatched(int id, MarketDispatchedDto marketDispatchedDto)
        {
            MarketDispatched marketDispatched = _mapper.Map<MarketDispatched>(marketDispatchedDto);
            marketDispatched.Id = id;
            marketDispatched.Created = _context.QualityMarketDispatched.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            marketDispatched.Modified = DateTime.Now;
            _context.Entry(marketDispatched).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketDispatchedExists(id))
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

        // POST: api/MarketDispatcheds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarketDispatched>> PostMarketDispatched(MarketDispatchedDto marketDispatchedDto)
        {
            MarketDispatched marketDispatched = _mapper.Map<MarketDispatched>(marketDispatchedDto);
            marketDispatched.Created = DateTime.Now;
            marketDispatched.Modified = marketDispatched.Created;
            _context.QualityMarketDispatched.Add(marketDispatched);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarketDispatched", new { id = marketDispatched.Id }, marketDispatched);
        }

        // DELETE: api/MarketDispatcheds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarketDispatched>> DeleteMarketDispatched(int id)
        {
            var marketDispatched = await _context.QualityMarketDispatched.FindAsync(id);
            if (marketDispatched == null)
            {
                return NotFound();
            }

            _context.QualityMarketDispatched.Remove(marketDispatched);
            await _context.SaveChangesAsync();

            return marketDispatched;
        }

        private bool MarketDispatchedExists(int id)
        {
            return _context.QualityMarketDispatched.Any(e => e.Id == id);
        }
    }
}
