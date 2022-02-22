using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
   // //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class IssueBasedRAController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IssueBasedRAController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IssueBasedRAHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueBasedRAHeader>>> GetIssueBasedRAHeader()
        {
            return await _context.IssueBasedRAHeader.ToListAsync();
        }

        // GET: api/IssueBasedRAHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IssueBasedRAHeader>> GetIssueBasedRAHeader(int id)
        {
            var issueBasedRAHeader = await _context.IssueBasedRAHeader.FindAsync(id);

            if (issueBasedRAHeader == null)
            {
                return NotFound();
            }

            return issueBasedRAHeader;
        }

        // PUT: api/IssueBasedRAHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssueBasedRAHeader(int id, IssueBasedRAHeader issueBasedRAHeader)
        {
            if (id != issueBasedRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(issueBasedRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueBasedRAHeaderExists(id))
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

        // POST: api/IssueBasedRAHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IssueBasedRAHeader>> PostIssueBasedRAHeader(IssueBasedRAHeader issueBasedRAHeader)
        {
            _context.IssueBasedRAHeader.Add(issueBasedRAHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssueBasedRAHeader", new { id = issueBasedRAHeader.Id }, issueBasedRAHeader);
        }

        // DELETE: api/IssueBasedRAHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IssueBasedRAHeader>> DeleteIssueBasedRAHeader(int id)
        {
            var issueBasedRAHeader = await _context.IssueBasedRAHeader.FindAsync(id);
            if (issueBasedRAHeader == null)
            {
                return NotFound();
            }

            _context.IssueBasedRAHeader.Remove(issueBasedRAHeader);
            await _context.SaveChangesAsync();

            return issueBasedRAHeader;
        }

        private bool IssueBasedRAHeaderExists(int id)
        {
            return _context.IssueBasedRAHeader.Any(e => e.Id == id);
        }
    }
}
