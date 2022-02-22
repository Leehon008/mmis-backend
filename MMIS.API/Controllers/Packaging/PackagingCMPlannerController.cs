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

    public class PackagingCMPlannerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public PackagingCMPlannerController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CMPlannerInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CMPlannerInput>>> GetCMPlannerInput()
        {
            return await _context.CMPlannerInput.ToListAsync();
        }

        // GET: api/CMPlannerInputs/5
        [HttpGet("{ShiftNo}")]
        public async Task<ActionResult<IEnumerable<CMPlannerInput>>> GetCMPlannerInput(string ShiftNo)
        {
            var CMPlannerInput = await _context.CMPlannerInput.Where(x => x.ShiftNo == ShiftNo).ToListAsync() ;

            if (CMPlannerInput == null)
            {
                return NotFound();
            }

            return CMPlannerInput;
        }

        // GET: api/CMPlannerInputs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CMPlannerInput>> GetCMPlannerInput(int id)
        {
            var CMPlannerInput = await _context.CMPlannerInput.FindAsync(id);

            if (CMPlannerInput == null)
            {
                return NotFound();
            }

            return CMPlannerInput;
        }

        // PUT: api/CMPlannerInputs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCMPlannerInput(int id, CMPlannerInput CMPlannerInput)
        {
            if (id != CMPlannerInput.Id)
            {
                return BadRequest();
            }
            //CMPlannerInput. = DateTime.Now;

            _context.Entry(CMPlannerInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CMPlannerInputExists(id))
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

        // POST: api/CMPlannerInputs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CMPlannerInput>> PostCMPlannerInput(List<CMPlannerInput> CMPlannerInput)
        {
            foreach (var CMPlannerInputData in CMPlannerInput)
            {
                _context.CMPlannerInput.Add(CMPlannerInputData);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCMPlannerInput", new { CMPlannerInput });
 
        }

        // DELETE: api/CMPlannerInputs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CMPlannerInput>> DeleteCMPlannerInput(int id)
        {
            var CMPlannerInput = await _context.CMPlannerInput.FindAsync(id);
            if (CMPlannerInput == null)
            {
                return NotFound();
            }

            _context.CMPlannerInput.Remove(CMPlannerInput);
            await _context.SaveChangesAsync();

            return CMPlannerInput;
        }

        private bool CMPlannerInputExists(int id)
        {
            return _context.CMPlannerInput.Any(e => e.Id == id);
        }
    }
}
