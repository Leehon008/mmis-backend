using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.Entities.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class LossWasteHeadersController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly ILWHeaderLogic _lwLogic;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;


        public LossWasteHeadersController(MMISDbContext context, ILWHeaderLogic lwLogic, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _lwLogic = lwLogic;
            _context = context;
        }


        // GET: api/LossWasteHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LossWasteHeader>>> GetLossWasteHeader()
        {
            return await _context.LossWasteHeader.ToListAsync();
        }

        // GET: api/LossWasteHeaders/5
        [HttpGet("{shiftNo}")]
        public async Task<ActionResult<IEnumerable<LossWasteHeader>>> GetLossWasteHeader(string shiftNo)
        {
            var lossWasteHeader = await _context.LossWasteHeader.Where(x => x.ShiftNo == shiftNo & x.ShiftStatus != 3).ToListAsync();

            if (lossWasteHeader == null)
            {
                return NotFound();
            }

            return lossWasteHeader;
        }

        // GET: api/LossWasteHeaders/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LossWasteHeader>> GetLossWasteHeader(int id)
        {
            var lossWasteHeader = await _context.LossWasteHeader.FindAsync(id);

            if (lossWasteHeader == null)
            {
                return NotFound();
            }

            return lossWasteHeader;
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<FeedBackPanevw>> GetByShift(string id)
        {
           
            var  sh =  _context.FeedBackPanevw.Where(m => m.ShiftNo.Equals(id)).FirstOrDefault();

            if (sh == null)
            {
                return NotFound();
            }

            return sh;
        }
        // PUT: api/LossWasteHeaders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> ApproveLossWasteHeader(int id, int status, LossWasteHeader lossWasteHeader)
        {
            if (id != lossWasteHeader.Id)
            {
                return BadRequest();
            }

            lossWasteHeader.ApprovalStatus = status;
            lossWasteHeader.ApprovedOn = DateTime.Now;
            lossWasteHeader.ApprovedBy = User.Identity.Name;
            var entry = _context.Entry(lossWasteHeader);
            entry.State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LossWasteHeaderExists(id))
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLossWasteHeader(int id, LossWasteHeader lossWasteHeader)
        {
            if (id != lossWasteHeader.Id)
            {
                return BadRequest();
            }
            lossWasteHeader.DateModified = DateTime.Now;
            lossWasteHeader.ApprovalStatus = 0;
            lossWasteHeader.ApprovedBy = null;

            var entry = _context.Entry(lossWasteHeader);
            entry.State = EntityState.Modified;

            if (lossWasteHeader.ShiftStatus != 3)
            {
                foreach (var navigationProperty in lossWasteHeader.LWFault.OrderByDescending(m => m.Id))
                {
                    bool delete = navigationProperty.Id < 0 ? true : false;
                    if (delete)
                    {
                        var entityEntry = _context.Entry(_context.LossWasteHeader.Find(lossWasteHeader.Id)
                            .LWFault.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                        entityEntry.State = EntityState.Deleted;

                        var nestedEntityEntry = _context.Entry(_context.LossWasteHeader.Find(lossWasteHeader.Id)
                                .LWFault.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                                .LWJobCard);
                        nestedEntityEntry.State = EntityState.Deleted;

                    }
                    else
                    {
                        var entityEntry = _context.Entry(navigationProperty);
                        entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;

                        var nestedEntityEntry = _context.Entry(_context.LossWasteHeader.Find(lossWasteHeader.Id)
                        .LWFault.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                        .LWJobCard);

                        nestedEntityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                    }

                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LossWasteHeaderExists(id))
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

        // POST: api/LossWasteHeaders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LossWasteHeader>> PostLossWasteHeader(LossWasteHeader lossWasteHeader)
        {
            lossWasteHeader.CreatedOn = DateTime.Now;
            lossWasteHeader.DateModified = DateTime.Now;
            lossWasteHeader.CreatedBy = User.Identity.Name;
            lossWasteHeader.ShiftStatus = 1;
            foreach (var navigationProperty in lossWasteHeader.LWFault)
            {
                navigationProperty.ModifiedBy = lossWasteHeader.ModifiedBy;
                navigationProperty.ShiftStatus = lossWasteHeader.ShiftStatus;

            }
            _context.LossWasteHeader.Add(lossWasteHeader);

            await _context.SaveChangesAsync();
            var complete = lossWasteHeader.LWFault.Where(m => (m.Level2.ToLower().Equals("program complete"))).Any();
            _ = updateShiftIntervals(lossWasteHeader.Plant, lossWasteHeader.ShiftNo, lossWasteHeader.ShiftInterval, complete);

            return CreatedAtAction("GetLossWasteHeader", new { id = lossWasteHeader.Id }, lossWasteHeader);
        }

        private async Task updateShiftIntervals(string Plant, string shiftname, int shiftInterval, bool status)
        {
            var shift = await _context.ShiftHeader.Where(m => m.PlantId.Contains(Plant) && m.ShiftGroupId.Equals("Packaging") && m.ShiftName == shiftname && m.StatusId != 3).OrderByDescending(m => m.Id).FirstOrDefaultAsync();

            _context.Attach(shift);
            var entry = _context.Entry(shift);
            entry.Property(e => e.ShiftNo).IsModified = false;

            foreach (var navigationProperty in shift.LWIntervals.OrderByDescending(m => m.Id))
            {
                if (navigationProperty.Interval == shiftInterval || status)
                {
                    navigationProperty.Status = true;
                }
                var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }


        // DELETE: api/LossWasteHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LossWasteHeader>> DeleteLossWasteHeader(int id)
        {
            var lossWasteHeader = await _context.LossWasteHeader.FindAsync(id);
            if (lossWasteHeader == null)
            {
                return NotFound();
            }

            var entry = _context.Entry(lossWasteHeader);
            entry.State = EntityState.Deleted;


            foreach (var navigationProperty in lossWasteHeader.LWFault.OrderByDescending(m => m.Id))
            {

                var entityEntry = _context.Entry(_context.LossWasteHeader.Find(lossWasteHeader.Id)
                    .LWFault.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;

                var nestedEntityEntry = _context.Entry(_context.LossWasteHeader.Find(lossWasteHeader.Id)
                        .LWFault.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                        .LWJobCard);
                nestedEntityEntry.State = EntityState.Deleted;

            }

            await _context.SaveChangesAsync();

            return lossWasteHeader;
        }

        private bool LossWasteHeaderExists(int id)
        {
            return _context.LossWasteHeader.Any(e => e.Id == id);
        }
    }
}
