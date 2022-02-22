using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]



    public class CalibrationsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CalibrationsController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/PIP
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Calibrations>>> GetQualityCalibrations()
        //{
        //    return await _context.QualityCalibrations.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calibrations>>> GetQualityCalibrations(string Plant)
        {
            return await _context.QualityCalibrations.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/PIP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calibrations>> GetCalibrations(int id)
        {
            var calibrations = await _context.QualityCalibrations.FindAsync(id);

            if (calibrations == null)
            {
                return NotFound();
            }

            return calibrations;
        }

        // PUT: api/PIP/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalibrations(int id, Calibrations calibrations)
        {
            if (id != calibrations.Id)
            {
                return BadRequest();
            }
            calibrations.Modified = DateTime.Now;
            //_context.Entry(calibrations).State = EntityState.Modified;
            _context.Attach(calibrations);

            var entry = _context.Entry(calibrations);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in calibrations.Alcolyser.OrderByDescending(m=>m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityCalibrations.Find(calibrations.Id)
                        .Alcolyser.Where(m=>m.Id== Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else if (navigationProperty.Id == 0)
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Added;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = EntityState.Modified;
                }
            }

            foreach (var navigationProperty in calibrations.pHMeter.OrderByDescending(m=>m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityCalibrations.Find(calibrations.Id)
                        .pHMeter.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else 
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in calibrations.Refractometer.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityCalibrations.Find(calibrations.Id)
                        .Refractometer.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            foreach (var navigationProperty in calibrations.Viscometer.OrderByDescending(m=>m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.QualityCalibrations.Find(calibrations.Id)
                        .Viscometer.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalibrationsExists(id))
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

        // POST: api/PIP
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Calibrations>> PostCalibrations(Calibrations calibrations)
        {
            calibrations.Created = DateTime.Now;
            calibrations.Modified = calibrations.Created;
            _context.QualityCalibrations.Add(calibrations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalibrations", new { id = calibrations.Id }, calibrations);
        }

        // DELETE: api/PIP/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calibrations>> DeleteCalibrations(int id)
        {
            var calibrations = await _context.QualityCalibrations.FindAsync(id);
            if (calibrations == null)
            {
                return NotFound();
            }

            _context.QualityCalibrations.Remove(calibrations);
            await _context.SaveChangesAsync();

            return calibrations;
        }

        private bool CalibrationsExists(int id)
        {
            return _context.QualityCalibrations.Any(e => e.Id == id);
        }
    }
}
