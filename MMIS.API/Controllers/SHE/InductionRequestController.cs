using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class InductionRequestController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public InductionRequestController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/InductionRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InductionRequest>>> GetInductionRequest()
        {
            return await _context.InductionRequest.ToListAsync();
        }

        // GET: api/InductionRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InductionRequest>> GetInductionRequest(int id)
        {
            var inductionRequest = await _context.InductionRequest.FindAsync(id);

            if (inductionRequest == null)
            {
                return NotFound();
            }

            return inductionRequest;
        }

        // PUT: api/InductionRequest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInductionRequest(int id, InductionRequest inductionRequest)
        {
            if (id != inductionRequest.Id)
            {
                return BadRequest();
            }
           // inductionRequest.DateCreated = DateTime.Now;
            inductionRequest.DateModified = DateTime.Now;
            _context.Entry(inductionRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InductionRequestExists(id))
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

        // POST: api/InductionRequest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InductionRequest>> PostInductionRequest(InductionRequest inductionRequest)
        {
            inductionRequest.DateCreated = DateTime.Now;
            inductionRequest.DateModified = DateTime.Now;
            _context.InductionRequest.Add(inductionRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInductionRequest", new { id = inductionRequest.Id }, inductionRequest);
        }

        // DELETE: api/InductionRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InductionRequest>> DeleteInductionRequest(int id)
        {
            var inductionRequest = await _context.InductionRequest.FindAsync(id);
            if (inductionRequest == null)
            {
                return NotFound();
            }

            _context.InductionRequest.Remove(inductionRequest);
            await _context.SaveChangesAsync();

            return inductionRequest;
        }

        private bool InductionRequestExists(int id)
        {
            return _context.InductionRequest.Any(e => e.Id == id);
        }
    }
}
