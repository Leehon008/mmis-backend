using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Entities.Shifts;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class PackagingDIArtisanController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingDIArtisanController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/DIArtisanInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DIArtisanInput>>> GetDIArtisanInput()
        {
            return await _context.DIArtisanInput.ToListAsync();
        }

        // GET: api/DIArtisanInputs/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<DIArtisanInput>>> GetDIArtisanInput(string ShiftNo)
        {
            var DIArtisanInput = await _context.DIArtisanInput.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (DIArtisanInput == null)
            {
                return NotFound();
            }

            return DIArtisanInput;
        }

        // GET: api/DIArtisanInputs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DIArtisanInput>> GetDIArtisanInput(int id)
        {
            var DIArtisanInput = await _context.DIArtisanInput.FindAsync(id);

            if (DIArtisanInput == null)
            {
                return NotFound();
            }

            return DIArtisanInput;
        }

        // PUT: api/DIArtisanInputs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDIArtisanInput(int id, DIArtisanInput DIArtisanInput)
        {
            if (id != DIArtisanInput.Id)
            {
                return BadRequest();
            }
            //DIArtisanInput. = DateTime.Now;

            _context.Entry(DIArtisanInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DIArtisanInputExists(id))
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

        // POST: api/DIArtisanInputs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DIArtisanInput>> PostDIArtisanInput(List<DIArtisanInput> DIArtisanInput)
        {
            foreach (var DIArtisanInputData in DIArtisanInput)
            {
                _context.DIArtisanInput.Add(DIArtisanInputData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetDIArtisanInput", new { DIArtisanInput });
 
        }

        // DELETE: api/DIArtisanInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DIArtisanInput>> DeleteDIArtisanInput(int id)
        {
            var DIArtisanInput = await _context.DIArtisanInput.FindAsync(id);
            if (DIArtisanInput == null)
            {
                return NotFound();
            }

            _context.DIArtisanInput.Remove(DIArtisanInput);
            await _context.SaveChangesAsync();

            return DIArtisanInput;
        }

        private bool DIArtisanInputExists(int id)
        {
            return _context.DIArtisanInput.Any(e => e.Id == id);
        }
    }
}
