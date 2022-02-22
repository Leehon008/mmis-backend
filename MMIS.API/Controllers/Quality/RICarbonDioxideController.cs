using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.Deviations;
using MMIS.BusinessLogicLayer.SHE.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;
using MMIS.DomainLayer.Quality.Models;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class RICarbonDioxideController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RICarbonDioxideController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/CarbonDioxideRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CarbonDioxideRI>>> GetCarbonDioxideRIs()
        //{
        //    return await _context.QualityRICarbonDioxide.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarbonDioxideRI>>> GetCarbonDioxideRIs(string Plant)
        {
            return await _context.QualityRICarbonDioxide.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/CarbonDioxideRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarbonDioxideRI>> GetCarbonDioxideRI(int id)
        {
            var carbonDioxideRI = await _context.QualityRICarbonDioxide.FindAsync(id);

            if (carbonDioxideRI == null)
            {
                return NotFound();
            }

            return carbonDioxideRI;
        }


        // GET: api/CarbonDioxideRIs/5
        [HttpGet("{batch}")]
        public async Task<ActionResult<CarbonDioxideRI>> GetCarbonDioxideRI(string batch)
        {
            var carbonDioxideRI = await _context.QualityRICarbonDioxide.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (carbonDioxideRI == null)
            {
                return NotFound();
            }

            return carbonDioxideRI;
        }
        // PUT: api/CarbonDioxideRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarbonDioxideRI(int id,CarbonDioxideRIDto carbonDioxideRIDto)
        {
            CarbonDioxideRI carbonDioxideRI = _mapper.Map<CarbonDioxideRI>(carbonDioxideRIDto);
            carbonDioxideRI.Id = id;
            carbonDioxideRI.Created = _context.QualityRICarbonDioxide.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            carbonDioxideRI.COA = _context.QualityRICarbonDioxide.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            carbonDioxideRI.Modified = DateTime.Now;
            //carbonDioxideRI.COA = _fileUploadLogic.UploadFile(carbonDioxideRIDto.COA, "Quality", "Inspections\\Packaging\\CarbonDioxide").Result;
            _context.Entry(carbonDioxideRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarbonDioxideRIExists(id))
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

        // POST: api/CarbonDioxideRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarbonDioxideRI>> PostCarbonDioxideRI([FromForm] CarbonDioxideRIDto carbonDioxideRIDto)
        {
            CarbonDioxideRI carbonDioxideRI = _mapper.Map<CarbonDioxideRI>(carbonDioxideRIDto);
            carbonDioxideRI.Created = DateTime.Now;
            carbonDioxideRI.Modified = carbonDioxideRI.Created;
            carbonDioxideRI.COA = _fileUploadLogic.UploadFile(carbonDioxideRIDto.COA,"Quality", "Inspections\\Packaging\\CarbonDioxide").Result;
            _context.QualityRICarbonDioxide.Add(carbonDioxideRI);
            await _context.SaveChangesAsync();

            DeviationLogic dLogic = new DeviationLogic(carbonDioxideRI.Deviation(), _context);
            _ = dLogic.Process();

            return CreatedAtAction("GetCarbonDioxideRI", new { id = carbonDioxideRI.Id }, carbonDioxideRI);
        }

        // DELETE: api/CarbonDioxideRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarbonDioxideRI>> DeleteCarbonDioxideRI(int id)
        {
            var carbonDioxideRI = await _context.QualityRICarbonDioxide.FindAsync(id);
            if (carbonDioxideRI == null)
            {
                return NotFound();
            }

            _context.QualityRICarbonDioxide.Remove(carbonDioxideRI);
            await _context.SaveChangesAsync();

            return carbonDioxideRI;
        }

        private bool CarbonDioxideRIExists(int id)
        {
            return _context.QualityRICarbonDioxide.Any(e => e.Id == id);
        }
    }
}
