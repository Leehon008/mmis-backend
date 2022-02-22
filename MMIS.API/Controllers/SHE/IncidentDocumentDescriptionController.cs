using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.SHE.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class IncidentDocumentDescriptionController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;
        public IncidentDocumentDescriptionController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }
    

        // GET: api/IncidentDocumentDescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentDocumentDescription>>> GetIncidentDocumentDescription()
        {
            return await _context.IncidentDocumentDescription.ToListAsync();
        }

        // GET: api/IncidentDocumentDescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentDocumentDescription>> GetIncidentDocumentDescription(string id)
        {
            int IId = _context.IncidentDocumentDescription.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();
            var incidentDocumentDescription = _context.IncidentDocumentDescription.Where(x => x.Id == IId).FirstOrDefault();

            //var incidentDocumentDescription = await _context.IncidentDocumentDescription.FindAsync(id);

            if (incidentDocumentDescription == null)
            {
                return NotFound();
            }

            return incidentDocumentDescription;
        }

        // PUT: api/IncidentDocumentDescription/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentDocumentDescription(string id, IncidentDocumentDescription incidentDocumentDescription)
        {
            int IId = _context.IncidentInvestigation.Where(m => m.IncidentNumber == id).Select(m => m.Id).FirstOrDefault();

            if (IId != incidentDocumentDescription.Id)
            {
                return BadRequest();
            }

            _context.Entry(incidentDocumentDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentDocumentDescriptionExists(IId))
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

        // POST: api/IncidentDocumentDescription
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        public async Task<ActionResult<IncidentDocumentDescription>> PostIncidentDocumentDescription([FromForm] IncidentDocumentDescriptionDto incidentDocumentDescriptionDto)
        {
            IncidentDocumentDescription data = _mapper.Map<IncidentDocumentDescription>(incidentDocumentDescriptionDto);
            data.FilePath = _fileUploadLogic.UploadFile(incidentDocumentDescriptionDto.files, "SHE", "IncidentDocumemtDescription").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
              
            _context.IncidentDocumentDescription.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidentDocumentDescription", new { id = data.Id }, data);
        }

        // DELETE: api/IncidentDocumentDescription/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentDocumentDescription>> DeleteIncidentDocumentDescription(int id)
        {
            var incidentDocumentDescription = await _context.IncidentDocumentDescription.FindAsync(id);
            if (incidentDocumentDescription == null)
            {
                return NotFound();
            }

            _context.IncidentDocumentDescription.Remove(incidentDocumentDescription);
            await _context.SaveChangesAsync();

            return incidentDocumentDescription;
        }

        private bool IncidentDocumentDescriptionExists(int id)
        {
            return _context.IncidentDocumentDescription.Any(e => e.Id == id);
        }
    }
}
