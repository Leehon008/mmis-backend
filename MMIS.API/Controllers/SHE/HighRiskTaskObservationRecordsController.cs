using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.SHE.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class HighRiskTaskObservationRecordsController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public HighRiskTaskObservationRecordsController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/HighRiskTaskObservationRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighRiskTaskObservationRecords>>> GetHighRiskTaskObservationRecords()
        {
            return await _context.HighRiskTaskObservationRecords.ToListAsync();
        }

        // GET: api/HighRiskTaskObservationRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HighRiskTaskObservationRecords>> GetHighRiskTaskObservationRecords(int id)
        {
            var highRiskTaskObservationRecords = await _context.HighRiskTaskObservationRecords.FindAsync(id);

            if (highRiskTaskObservationRecords == null)
            {
                return NotFound();
            }

            return highRiskTaskObservationRecords;
        }

        // PUT: api/HighRiskTaskObservationRecords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighRiskTaskObservationRecords(int id, HighRiskTaskObservationRecords highRiskTaskObservationRecords)
        {
            if (id != highRiskTaskObservationRecords.Id)
            {
                return BadRequest();
            }
            highRiskTaskObservationRecords.DateCreated = DateTime.Now;
            highRiskTaskObservationRecords.DateModified = DateTime.Now;
            _context.Entry(highRiskTaskObservationRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighRiskTaskObservationRecordsExists(id))
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

        // POST: api/HighRiskTaskObservationRecords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        public async Task<ActionResult<HighRiskTaskObservationRecords>> PostAppointments([FromForm] HighRiskTaskObservationRecordDto highRiskTaskObservationRecords)
        {
            HighRiskTaskObservationRecords data = _mapper.Map<HighRiskTaskObservationRecords>(highRiskTaskObservationRecords);
            data.FilePath = _fileUploadLogic.UploadFile(highRiskTaskObservationRecords.files, "SHE", "TaskObservations").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
           _context.HighRiskTaskObservationRecords.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHighRiskTaskObservationRecords", new { id = data.Id }, data);
        }

        // DELETE: api/HighRiskTaskObservationRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HighRiskTaskObservationRecords>> DeleteHighRiskTaskObservationRecords(int id)
        {
            var highRiskTaskObservationRecords = await _context.HighRiskTaskObservationRecords.FindAsync(id);
            if (highRiskTaskObservationRecords == null)
            {
                return NotFound();
            }

            _context.HighRiskTaskObservationRecords.Remove(highRiskTaskObservationRecords);
            await _context.SaveChangesAsync();

            return highRiskTaskObservationRecords;
        }

        private bool HighRiskTaskObservationRecordsExists(int id)
        {
            return _context.HighRiskTaskObservationRecords.Any(e => e.Id == id);
        }
    }
}
