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

    public class AuditRecordsController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public AuditRecordsController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/AuditRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditRecords>>> GetAuditRecords()
        {
            return await _context.AuditRecords.ToListAsync();
        }

        // GET: api/AuditRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditRecords>> GetAuditRecords(int id)
        {
            var auditRecords = await _context.AuditRecords.FindAsync(id);

            if (auditRecords == null)
            {
                return NotFound();
            }

            return auditRecords;
        }

        // PUT: api/AuditRecords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditRecords(int id, AuditRecords auditRecords)
        {
            if (id != auditRecords.Id)
            {
                return BadRequest();
            }
           // auditRecords.DateCreated = DateTime.Now;
            auditRecords.DateModified = DateTime.Now;
            _context.Entry(auditRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditRecordsExists(id))
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

        // POST: api/AuditRecords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuditRecords>> PostAppointments([FromForm] AuditRecordsDto auditRecords)
        {
            AuditRecords data = _mapper.Map<AuditRecords>(auditRecords);
            data.FilePath = _fileUploadLogic.UploadFile(auditRecords.files, "SHE", "AuditRecords").Result;
            auditRecords.DateCreated = DateTime.Now;
            auditRecords.DateModified = DateTime.Now;
            _context.AuditRecords.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditRecords", new { id = data.Id }, data);
        }
 

        // DELETE: api/AuditRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditRecords>> DeleteAuditRecords(int id)
        {
            var auditRecords = await _context.AuditRecords.FindAsync(id);
            if (auditRecords == null)
            {
                return NotFound();
            }

            _context.AuditRecords.Remove(auditRecords);
            await _context.SaveChangesAsync();

            return auditRecords;
        }

        private bool AuditRecordsExists(int id)
        {
            return _context.AuditRecords.Any(e => e.Id == id);
        }
    }
}
