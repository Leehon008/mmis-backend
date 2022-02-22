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
using MMIS.DomainLayer.Quality.Entities;
using MMIS.DomainLayer.Quality.Models;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class CIPTrackerController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public CIPTrackerController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/CIPTrackers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CIPTracker>>> GetCIPTrackers()
        //{
        //    return await _context.QualityCIPTracker.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CIPTracker>>> GetCIPTrackers(string Plant)
        {
            return await _context.QualityCIPTracker.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/CIPTrackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CIPTracker>> GetCIPTracker(int id)
        {
            var cip = await _context.QualityCIPTracker.FindAsync(id);

            if (cip == null)
            {
                return NotFound();
            }

            return cip;
        }

        [HttpGet("{batch}")]


        // PUT: api/CIPTrackers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCIPTracker(int id,CIPTrackerDto cipDto)
        {
            CIPTracker cip = _mapper.Map<CIPTracker>(cipDto);
            cip.Id = id;
            cip.Created = await _context.QualityCIPTracker.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            cip.Deviation = await _context.QualityCIPTracker.Where(m => m.Id == id).Select(m => m.Deviation).FirstOrDefaultAsync();
            cip.Modified = DateTime.Now;
            //cip.COA = _fileUploadLogic.UploadFile(cipDto.COA, "Quality", "CIP Deviations").Result;

            _context.Entry(cip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CIPTrackerExists(id))
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

        // POST: api/CIPTrackers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CIPTracker>> PostCIPTracker([FromForm] CIPTrackerDto cipDto)
        {
            CIPTracker cip = _mapper.Map<CIPTracker>(cipDto);
            cip.Created = DateTime.Now;
            cip.Modified = cip.Created;
            cip.Deviation = _fileUploadLogic.UploadFile(cipDto.Deviation, "Quality", "CIP Deviations").Result;
            _context.QualityCIPTracker.Add(cip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCIPTracker", new { id = cip.Id }, cip);
        }

        // DELETE: api/CIPTrackers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CIPTracker>> DeleteCIPTracker(int id)
        {
            var cip = await _context.QualityCIPTracker.FindAsync(id);
            if (cip == null)
            {
                return NotFound();
            }

            _context.QualityCIPTracker.Remove(cip);
            await _context.SaveChangesAsync();

            return cip;
        }

        private bool CIPTrackerExists(int id)
        {
            return _context.QualityCIPTracker.Any(e => e.Id == id);
        }
    }
}
