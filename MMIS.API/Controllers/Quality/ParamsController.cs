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

    public class ParamsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public ParamsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Params
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Params>>> GetQualityParams()
        {
            return await _context.QualityParams.ToListAsync();
        }

        // GET: api/Params/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Params>> GetParams(int id)
        {
            var @params = await _context.QualityParams.FindAsync(id);

            if (@params == null)
            {
                return NotFound();
            }

            return @params;
        }

        // PUT: api/Params/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParams(int id, Params @params)
        {
            if (id != @params.Id)
            {
                return BadRequest();
            }

            _context.Entry(@params).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamsExists(id))
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

        // POST: api/Params
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Params>> PostParams(Params @params)
        {
            _context.QualityParams.Add(@params);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParams", new { id = @params.Id }, @params);
        }

        // DELETE: api/Params/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Params>> DeleteParams(int id)
        {
            var @params = await _context.QualityParams.FindAsync(id);
            if (@params == null)
            {
                return NotFound();
            }

            _context.QualityParams.Remove(@params);
            await _context.SaveChangesAsync();

            return @params;
        }

        private bool ParamsExists(int id)
        {
            return _context.QualityParams.Any(e => e.Id == id);
        }
    }
}
