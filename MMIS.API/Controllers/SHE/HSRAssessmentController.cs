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

    public class HSRAssessmentController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;


        public HSRAssessmentController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/HRAssessment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HRAHeader>>> GetHRAHeader()
        {
            return await _context.HRAHeader.ToListAsync();
        }

        // GET: api/HRAssessment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HRAHeader>> GetHRAHeader(int id)
        {
            var hRAHeader = await _context.HRAHeader.FindAsync(id);

            if (hRAHeader == null)
            {
                return NotFound();
            }

            return hRAHeader;
        }

        // PUT: api/HRAssessment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHRAHeader(int id, HRAHeader hRAHeader)
        {
            if (id != hRAHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(hRAHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HRAHeaderExists(id))
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

        // POST: api/HRAssessment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
     
        [HttpPost]
        public async Task<ActionResult<HRAHeader>> PostHRAHeader( HRAHeader hRAHeader)
        {
                HRAHeader data = _mapper.Map<HRAHeader>(hRAHeader);
               // data.Path = _fileUploadLogic.UploadFile(hRAHeader.files, "SHE", "SRA").Result;
                data.DateCreated = DateTime.Now;
                data.DateModified = DateTime.Now;
                _context.HRAHeader.Add(data);
                await _context.SaveChangesAsync();

            return CreatedAtAction("GetHRAHeader", new { id = data.Id }, data);
        }

        // DELETE: api/HRAssessment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HRAHeader>> DeleteHRAHeader(int id)
        {
            var hRAHeader = await _context.HRAHeader.FindAsync(id);
            if (hRAHeader == null)
            {
                return NotFound();
            }

            _context.HRAHeader.Remove(hRAHeader);
            await _context.SaveChangesAsync();

            return hRAHeader;
        }

        private bool HRAHeaderExists(int id)
        {
            return _context.HRAHeader.Any(e => e.Id == id);
        }
    }
}
