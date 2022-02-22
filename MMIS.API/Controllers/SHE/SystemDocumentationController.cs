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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class SystemDocumentationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SystemDocumentationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemDocumentation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemDocumentation>>> GetSystemDocumentation()
        {
            return await _context.SystemDocumentation.ToListAsync();
        }

        // GET: api/SystemDocumentation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemDocumentation>> GetSystemDocumentation(int id)
        {
            var systemDocumentation = await _context.SystemDocumentation.FindAsync(id);

            if (systemDocumentation == null)
            {
                return NotFound();
            }

            return systemDocumentation;
        }

        // PUT: api/SystemDocumentation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemDocumentation(int id, SystemDocumentation systemDocumentation)
        {
            if (id != systemDocumentation.Id)
            {
                return BadRequest();
            }
            systemDocumentation.DateModified = DateTime.Now;
           
            _context.Entry(systemDocumentation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemDocumentationExists(id))
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

        // POST: api/SystemDocumentation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SystemDocumentation>> PostSystemDocumentation(SystemDocumentation systemDocumentation)
        {
            systemDocumentation.DateModified = DateTime.Now;
            systemDocumentation.DateCreated = DateTime.Now;
            _context.SystemDocumentation.Add(systemDocumentation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemDocumentation", new { id = systemDocumentation.Id }, systemDocumentation);
        }

        // DELETE: api/SystemDocumentation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SystemDocumentation>> DeleteSystemDocumentation(int id)
        {
            var systemDocumentation = await _context.SystemDocumentation.FindAsync(id);
            if (systemDocumentation == null)
            {
                return NotFound();
            }

            _context.SystemDocumentation.Remove(systemDocumentation);
            await _context.SaveChangesAsync();

            return systemDocumentation;
        }

        private bool SystemDocumentationExists(int id)
        {
            return _context.SystemDocumentation.Any(e => e.Id == id);
        }
    }
}
