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


    public class RIPreformController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIPreformController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/PreformRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PreformRI>>> GetPreformRIs()
        //{
        //    return await _context.QualityRIPreform.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreformRI>>> GetPreformRIs(string Plant)
        {
            return await _context.QualityRIPreform.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/PreformRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreformRI>> GetPreformRI(int id)
        {
            var preformRI = await _context.QualityRIPreform.FindAsync(id);

            if (preformRI == null)
            {
                return NotFound();
            }

            return preformRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<PreformRI>> GetPreformRI(string batch)
        {
            var preformRI = await _context.QualityRIPreform.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (preformRI == null)
            {
                return NotFound();
            }

            return preformRI;
        }

        // PUT: api/PreformRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreformRI(int id,PreformRIDto preformRIDto)
        {
            PreformRI preformRI = _mapper.Map<PreformRI>(preformRIDto);
            preformRI.Id = id;
            preformRI.Created = await _context.QualityRIPreform.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            preformRI.COA = await _context.QualityRIPreform.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            preformRI.Modified = DateTime.Now;
            //preformRI.COA = _fileUploadLogic.UploadFile(preformRIDto.COA, "Quality", "Inspections\\Packaging\\Preforms").Result;

            _context.Entry(preformRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreformRIExists(id))
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

        // POST: api/PreformRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreformRI>> PostPreformRI([FromForm] PreformRIDto preformRIDto)
        {
            PreformRI preformRI = _mapper.Map<PreformRI>(preformRIDto);
            preformRI.Created = DateTime.Now;
            preformRI.Modified = preformRI.Created;
            preformRI.COA = _fileUploadLogic.UploadFile(preformRIDto.COA, "Quality", "Inspections\\Packaging\\Preforms").Result;
            _context.QualityRIPreform.Add(preformRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreformRI", new { id = preformRI.Id }, preformRI);
        }

        // DELETE: api/PreformRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreformRI>> DeletePreformRI(int id)
        {
            var preformRI = await _context.QualityRIPreform.FindAsync(id);
            if (preformRI == null)
            {
                return NotFound();
            }

            _context.QualityRIPreform.Remove(preformRI);
            await _context.SaveChangesAsync();

            return preformRI;
        }

        private bool PreformRIExists(int id)
        {
            return _context.QualityRIPreform.Any(e => e.Id == id);
        }
    }
}
