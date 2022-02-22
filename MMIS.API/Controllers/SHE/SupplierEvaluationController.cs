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

    public class SupplierEvaluationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public SupplierEvaluationController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/SupplierEvaluation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierEvaluation>>> GetSupplierEvaluation()
        {
            return await _context.SupplierEvaluation.ToListAsync();
        }

        // GET: api/SupplierEvaluation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierEvaluation>> GetSupplierEvaluation(int id)
        {
            var supplierEvaluation = await _context.SupplierEvaluation.FindAsync(id);

            if (supplierEvaluation == null)
            {
                return NotFound();
            }

            return supplierEvaluation;
        }

        // PUT: api/SupplierEvaluation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierEvaluation(int id, SupplierEvaluation supplierEvaluation)
        {
            if (id != supplierEvaluation.Id)
            {
                return BadRequest();
            }
            supplierEvaluation.DateModified = DateTime.Now;
            _context.Entry(supplierEvaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierEvaluationExists(id))
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

        // POST: api/SupplierEvaluation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SupplierEvaluation>> PostSupplierEvaluation(SupplierEvaluation supplierEvaluation)
        {
            supplierEvaluation.DateModified = DateTime.Now;
            supplierEvaluation.DateCreated = DateTime.Now;
            _context.SupplierEvaluation.Add(supplierEvaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplierEvaluation", new { id = supplierEvaluation.Id }, supplierEvaluation);
        }

        // DELETE: api/SupplierEvaluation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierEvaluation>> DeleteSupplierEvaluation(int id)
        {
            var supplierEvaluation = await _context.SupplierEvaluation.FindAsync(id);
            if (supplierEvaluation == null)
            {
                return NotFound();
            }

            _context.SupplierEvaluation.Remove(supplierEvaluation);
            await _context.SaveChangesAsync();

            return supplierEvaluation;
        }

        private bool SupplierEvaluationExists(int id)
        {
            return _context.SupplierEvaluation.Any(e => e.Id == id);
        }
    }
}
