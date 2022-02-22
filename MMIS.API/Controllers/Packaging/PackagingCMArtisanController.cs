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

    public class PackagingCMArtisanController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingCMArtisanController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CMArtisanInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CMArtisanInput>>> GetCMArtisanInput()
        {
            return await _context.CMArtisanInput.ToListAsync();
        }

        // GET: api/CMArtisanInputs/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<CMArtisanInput>>> GetCMArtisanInput(string ShiftNo)
        {
            var CMArtisanInput = await _context.CMArtisanInput.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (CMArtisanInput == null)
            {
                return NotFound();
            }

            return CMArtisanInput;
        }

        // GET: api/CMArtisanInputs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CMArtisanInput>> GetCMArtisanInput(int id)
        {
            var CMArtisanInput = await _context.CMArtisanInput.FindAsync(id);

            if (CMArtisanInput == null)
            {
                return NotFound();
            }

            return CMArtisanInput;
        }

        // PUT: api/CMArtisanInputs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCMArtisanInput(int id, CMArtisanInput CMArtisanInput)
        {
            if (id != CMArtisanInput.Id)
            {
                return BadRequest();
            }
            //CMArtisanInput. = DateTime.Now;

            _context.Entry(CMArtisanInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CMArtisanInputExists(id))
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

        // POST: api/CMArtisanInputs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CMArtisanInput>> PostCMArtisanInput(List<CMArtisanInput> CMArtisanInput)
        {
            foreach (var CMArtisanInputData in CMArtisanInput)
            {
                _context.CMArtisanInput.Add(CMArtisanInputData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCMArtisanInput", new { CMArtisanInput });
 
        }

        // DELETE: api/CMArtisanInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CMArtisanInput>> DeleteCMArtisanInput(int id)
        {
            var CMArtisanInput = await _context.CMArtisanInput.FindAsync(id);
            if (CMArtisanInput == null)
            {
                return NotFound();
            }

            _context.CMArtisanInput.Remove(CMArtisanInput);
            await _context.SaveChangesAsync();

            return CMArtisanInput;
        }

        private bool CMArtisanInputExists(int id)
        {
            return _context.CMArtisanInput.Any(e => e.Id == id);
        }
    }
}
