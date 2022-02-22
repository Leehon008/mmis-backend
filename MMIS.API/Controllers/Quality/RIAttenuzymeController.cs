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


    public class RIAttenuzymeController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIAttenuzymeController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttenuzymeRI>>> GetAttenuzymeRI(string Plant)
        {
            return await _context.QualityRIAttenuzymeRI.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/AttenuzymeRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttenuzymeRI>> GetAttenuzymeRI(int id)
        {
            var labelRI = await _context.QualityRIAttenuzymeRI.FindAsync(id);

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<AttenuzymeRI>> Get(string batch)
        {
            var labelRI = await _context.QualityRIAttenuzymeRI.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }

        // PUT: api/AttenuzymeRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttenuzymeRI(int id, AttenuzymeRIDto obj)
        {
            AttenuzymeRI labelRI = _mapper.Map<AttenuzymeRI>(obj);
            labelRI.Id = id;
            labelRI.Created = _context.QualityRIAttenuzymeRI.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            labelRI.COA = _context.QualityRIAttenuzymeRI.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            labelRI.Modified = DateTime.Now;
            //labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\Labels").Result;
            _context.Entry(labelRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttenuzymeRIExists(id))
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

        // POST: api/AttenuzymeRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AttenuzymeRI>> PostAttenuzymeRI([FromForm] AttenuzymeRIDto obj)
        {
            AttenuzymeRI labelRI = _mapper.Map<AttenuzymeRI>(obj);
            labelRI.Created = DateTime.Now;
            labelRI.Modified = labelRI.Created;
            labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality","Inspections\\Brewing\\Attenuzyme").Result;
            _context.QualityRIAttenuzymeRI.Add(labelRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttenuzymeRI", new { id = labelRI.Id }, labelRI);
        }

        // DELETE: api/AttenuzymeRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AttenuzymeRI>> DeleteAttenuzymeRI(int id)
        {
            var labelRI = await _context.QualityRIAttenuzymeRI.FindAsync(id);
            if (labelRI == null)
            {
                return NotFound();
            }

            _context.QualityRIAttenuzymeRI.Remove(labelRI);
            await _context.SaveChangesAsync();

            return labelRI;
        }

        private bool AttenuzymeRIExists(int id)
        {
            return _context.QualityRIAttenuzymeRI.Any(e => e.Id == id);
        }
    }
}
