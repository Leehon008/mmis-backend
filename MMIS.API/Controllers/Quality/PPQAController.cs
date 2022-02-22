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

    public class PPQAController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PPQAController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PPQA
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PPQA>>> GetQualityPPQA()
        //{
        //    return await _context.QualityPPQA.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PPQA>>> GetQualityPPQA(string Plant)
        {
            return await _context.QualityPPQA.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/PPQA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PPQA>> GetPPQA(int id)
        {
            var PPQA = await _context.QualityPPQA.FindAsync(id);

            if (PPQA == null)
            {
                return NotFound();
            }

            return PPQA;
        }

        // PUT: api/PPQA/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPPQA(int id, PPQA PPQA)
        {
            if (id != PPQA.Id)
            {
                return BadRequest();
            }

            PPQA.Modified = DateTime.Now;
            //_context.Entry(PPQA).State = EntityState.Modified;
            _context.Attach(PPQA);

            var entry = _context.Entry(PPQA);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;
            //_context.Entry(PPQA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PPQAExists(id))
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

        // POST: api/PPQA
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PPQA>> PostPPQA(PPQA PPQA)
        {
            PPQA.Created = DateTime.Now;
            PPQA.Modified = PPQA.Created;
            _context.QualityPPQA.Add(PPQA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPPQA", new { id = PPQA.Id }, PPQA);
        }

        // DELETE: api/PPQA/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PPQA>> DeletePPQA(int id)
        {
            var PPQA = await _context.QualityPPQA.FindAsync(id);
            if (PPQA == null)
            {
                return NotFound();
            }

            _context.QualityPPQA.Remove(PPQA);
            await _context.SaveChangesAsync();

            return PPQA;
        }

        private bool PPQAExists(int id)
        {
            return _context.QualityPPQA.Any(e => e.Id == id);
        }
    }
}
