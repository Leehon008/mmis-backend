using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class EnvironmentalIncidentMediaController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public EnvironmentalIncidentMediaController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvironmentalIncidentMedia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvironmentalIncidentMedia>>> GetEnvironmentalIncidentMedia()
        {
            return await _context.EnvironmentalIncidentMedia.ToListAsync();
        }

        // GET: api/EnvironmentalIncidentMedia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvironmentalIncidentMedia>> GetEnvironmentalIncidentMedia(string id)
        {

            int IId = _context.EnvironmentalIncidentMedia.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var environmentalIncidentMedia = _context.EnvironmentalIncidentMedia.Where(x => x.Id == IId).FirstOrDefault();

           // var environmentalIncidentMedia = await _context.EnvironmentalIncidentMedia.FindAsync(id);

            if (environmentalIncidentMedia == null)
            {
                return NotFound();
            }

            return environmentalIncidentMedia;
        }

        // PUT: api/EnvironmentalIncidentMedia/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmentalIncidentMedia(string id, EnvironmentalIncidentMedia environmentalIncidentMedia)
        {
            int IId = _context.EnvironmentalIncidentMedia.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != environmentalIncidentMedia.Id)
            {
                return BadRequest();
            }
            environmentalIncidentMedia.DateModified = DateTime.Now;
     //       environmentalIncidentMedia.DateCreated = DateTime.Now;



            _context.Entry(environmentalIncidentMedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentalIncidentMediaExists(IId))
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

        // POST: api/EnvironmentalIncidentMedia
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnvironmentalIncidentMedia>> PostEnvironmentalIncidentMedia(EnvironmentalIncidentMedia environmentalIncidentMedia)
        {
            environmentalIncidentMedia.DateModified = DateTime.Now;
            environmentalIncidentMedia.DateCreated = DateTime.Now;
            _context.EnvironmentalIncidentMedia.Add(environmentalIncidentMedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmentalIncidentMedia", new { id = environmentalIncidentMedia.Id }, environmentalIncidentMedia);
        }

        // DELETE: api/EnvironmentalIncidentMedia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnvironmentalIncidentMedia>> DeleteEnvironmentalIncidentMedia(int id)
        {
            var environmentalIncidentMedia = await _context.EnvironmentalIncidentMedia.FindAsync(id);
            if (environmentalIncidentMedia == null)
            {
                return NotFound();
            }

            _context.EnvironmentalIncidentMedia.Remove(environmentalIncidentMedia);
            await _context.SaveChangesAsync();

            return environmentalIncidentMedia;
        }

        private bool EnvironmentalIncidentMediaExists(int id)
        {
            return _context.EnvironmentalIncidentMedia.Any(e => e.Id == id);
        }
    }
}
