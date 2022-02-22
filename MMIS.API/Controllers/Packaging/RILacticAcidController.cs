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


    public class RILacticAcidController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RILacticAcidController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/LacticAcidRIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LacticAcidRI>>> GetLacticAcidRIs(string plant)
        {
            return await _context.QualityRILacticAcid.Where(m => m.Plant.Contains(plant)).ToListAsync();
        }

        // GET: api/LacticAcidRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LacticAcidRI>> GetLacticAcidRI(int id)
        {
            var lacticAcidRI = await _context.QualityRILacticAcid.FindAsync(id);

            if (lacticAcidRI == null)
            {
                return NotFound();
            }

            return lacticAcidRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<LacticAcidRI>> GetLacticAcidRI(string batch)
        {
            var lacticAcidRI = await _context.QualityRILacticAcid.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (lacticAcidRI == null)
            {
                return NotFound();
            }

            return lacticAcidRI;
        }

        // PUT: api/LacticAcidRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLacticAcidRI(int id,LacticAcidRIDto lacticAcidRIDto)
        {
            LacticAcidRI lacticAcidRI = _mapper.Map<LacticAcidRI>(lacticAcidRIDto);
            lacticAcidRI.Id = id;
            lacticAcidRI.Created = _context.QualityRILacticAcid.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            lacticAcidRI.COA = _context.QualityRILacticAcid.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            lacticAcidRI.Modified = DateTime.Now;
            //lacticAcidRI.COA = _fileUploadLogic.UploadFile(lacticAcidRIDto.COA, "Quality", "Inspections\\Brewing\\LacticAcid").Result;

            _context.Entry(lacticAcidRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LacticAcidRIExists(id))
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

        // POST: api/LacticAcidRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LacticAcidRI>> PostLacticAcidRI([FromForm] LacticAcidRIDto lacticAcidRIDto)
        {
            LacticAcidRI lacticAcidRI = _mapper.Map<LacticAcidRI>(lacticAcidRIDto);
            lacticAcidRI.Created = DateTime.Now;
            lacticAcidRI.Modified = lacticAcidRI.Created;
            lacticAcidRI.COA = _fileUploadLogic.UploadFile(lacticAcidRIDto.COA, "Quality", "Inspections\\Brewing\\LacticAcid").Result;
            _context.QualityRILacticAcid.Add(lacticAcidRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLacticAcidRI", new { id = lacticAcidRI.Id }, lacticAcidRI);
        }

        // DELETE: api/LacticAcidRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LacticAcidRI>> DeleteLacticAcidRI(int id)
        {
            var lacticAcidRI = await _context.QualityRILacticAcid.FindAsync(id);
            if (lacticAcidRI == null)
            {
                return NotFound();
            }

            _context.QualityRILacticAcid.Remove(lacticAcidRI);
            await _context.SaveChangesAsync();

            return lacticAcidRI;
        }

        private bool LacticAcidRIExists(int id)
        {
            return _context.QualityRILacticAcid.Any(e => e.Id == id);
        }
    }
}
