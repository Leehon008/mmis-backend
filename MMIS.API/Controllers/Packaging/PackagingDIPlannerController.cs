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

    public class PackagingDIPlannerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingDIPlannerController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/DIPlannerInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DIPlannerInput>>> GetDIPlannerInput()
        {
            return await _context.DIPlannerInput.ToListAsync();
        }

        // GET: api/DIPlannerInputs/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<DIPlannerInput>>> GetDIPlannerInput(string ShiftNo)
        {
            var DIPlannerInput = await _context.DIPlannerInput.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (DIPlannerInput == null)
            {
                return NotFound();
            }

            return DIPlannerInput;
        }

        // GET: api/DIPlannerInputs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DIPlannerInput>> GetDIPlannerInput(int id)
        {
            var DIPlannerInput = await _context.DIPlannerInput.FindAsync(id);

            if (DIPlannerInput == null)
            {
                return NotFound();
            }

            return DIPlannerInput;
        }

        // PUT: api/DIPlannerInputs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDIPlannerInput(int id, DIPlannerInput DIPlannerInput)
        {
            if (id != DIPlannerInput.Id)
            {
                return BadRequest();
            }
            //DIPlannerInput. = DateTime.Now;

            _context.Entry(DIPlannerInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DIPlannerInputExists(id))
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

        // POST: api/DIPlannerInputs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DIPlannerInput>> PostDIPlannerInput(List<DIPlannerInput> DIPlannerInput)
        {
            foreach (var DIPlannerInputData in DIPlannerInput)
            {
                _context.DIPlannerInput.Add(DIPlannerInputData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetDIPlannerInput", new { DIPlannerInput });
 
        }

        // DELETE: api/DIPlannerInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DIPlannerInput>> DeleteDIPlannerInput(int id)
        {
            var DIPlannerInput = await _context.DIPlannerInput.FindAsync(id);
            if (DIPlannerInput == null)
            {
                return NotFound();
            }

            _context.DIPlannerInput.Remove(DIPlannerInput);
            await _context.SaveChangesAsync();

            return DIPlannerInput;
        }

        private bool DIPlannerInputExists(int id)
        {
            return _context.DIPlannerInput.Any(e => e.Id == id);
        }
    }
}
