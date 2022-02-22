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

    public class MedicalDataController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public MedicalDataController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalData>>> GetMedicalData()
        {
            return await _context.MedicalData.ToListAsync();
        }

        // GET: api/MedicalData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalData>> GetMedicalData(long id)
        {
            var medicalData = await _context.MedicalData.FindAsync(id);

            if (medicalData == null)
            {
                return NotFound();
            }

            return medicalData;
        }

        // PUT: api/MedicalData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutMedicalData(long id, MedicalData medicalData)
        //{
        //    if (id != medicalData.Id)
        //    {
        //        return BadRequest();
        //    }

        //    medicalData.DateModified = DateTime.Now;
        //    _context.Entry(medicalData).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MedicalDataExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public async Task<IActionResult> PutMedicalData(int id, MedicalData medicalData)
        {
            if (id != medicalData.Id)
            {
                return BadRequest();
            }

            //_context.Entry(brewingCycle).State = EntityState.Modified;
            medicalData.DateModified = DateTime.Now;
            _context.Attach(medicalData);

            var entry = _context.Entry(medicalData);
            entry.State = EntityState.Modified;
            entry.Property(e => e.DateCreated).IsModified = false;

            foreach (var navigationProperty in medicalData.Medicals.OrderByDescending(m => m.Id))
            {
                
                
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Modified;
                
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalDataExists(id))
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

        // POST: api/MedicalData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicalData>> PostMedicalData(MedicalData medicalData)
        {
            medicalData.DateCreated = DateTime.Now;
            medicalData.DateModified = DateTime.Now;
            _context.MedicalData.Add(medicalData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalData", new { id = medicalData.Id }, medicalData);
        }

        // DELETE: api/MedicalData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalData>> DeleteMedicalData(long id)
        {
            var medicalData = await _context.MedicalData.FindAsync(id);
            if (medicalData == null)
            {
                return NotFound();
            }

            _context.MedicalData.Remove(medicalData);
            await _context.SaveChangesAsync();

            return medicalData;
        }

        private bool MedicalDataExists(long id)
        {
            return _context.MedicalData.Any(e => e.Id == id);
        }
    }
}
