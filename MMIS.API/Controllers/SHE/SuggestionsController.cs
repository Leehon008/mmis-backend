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

    public class SuggestionsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SuggestionsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/Suggestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suggestions>>> GetSuggestions()
        {
            return await _context.Suggestions.ToListAsync();
        }

        // GET: api/Suggestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suggestions>> GetSuggestions(long id)
        {
            var suggestions = await _context.Suggestions.FindAsync(id);

            if (suggestions == null)
            {
                return NotFound();
            }

            return suggestions;
        }

        // PUT: api/Suggestions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuggestions(long id, Suggestions suggestions)
        {
            if (id != suggestions.Id)
            {
                return BadRequest();
            }
      
             suggestions.DateModified = DateTime.Now;
            _context.Entry(suggestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestionsExists(id))
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

        // POST: api/Suggestions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Suggestions>> PostSuggestions(Suggestions suggestions)
        {
            suggestions.dateCreated = DateTime.Now;
            suggestions.DateModified = DateTime.Now;
            _context.Suggestions.Add(suggestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuggestions", new { id = suggestions.Id }, suggestions);
        }

        // DELETE: api/Suggestions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suggestions>> DeleteSuggestions(long id)
        {
            var suggestions = await _context.Suggestions.FindAsync(id);
            if (suggestions == null)
            {
                return NotFound();
            }

            _context.Suggestions.Remove(suggestions);
            await _context.SaveChangesAsync();

            return suggestions;
        }

        private bool SuggestionsExists(long id)
        {
            return _context.Suggestions.Any(e => e.Id == id);
        }
    }
}
