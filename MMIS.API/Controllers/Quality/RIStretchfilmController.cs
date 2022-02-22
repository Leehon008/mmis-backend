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

  // // [Microsoft.AspNetCore.Authorization.Authorize]
    public class RIStretchfilmController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIStretchfilmController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/StretchfilmRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StretchfilmRI>>> GetStretchfilmRIs()
        //{
        //    return await _context.QualityRIStretchfilm.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StretchfilmRI>>> GetStretchfilmRIs(string Plant)
        {
            return await _context.QualityRIStretchfilm.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/StretchfilmRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StretchfilmRI>> GetStretchfilmRI(int id)
        {
            var stretchfilmRI = await _context.QualityRIStretchfilm.FindAsync(id);

            if (stretchfilmRI == null)
            {
                return NotFound();
            }

            return stretchfilmRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<StretchfilmRI>> GetStretchfilmRI(string batch)
        {
            var stretchfilmRI = await _context.QualityRIStretchfilm.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (stretchfilmRI == null)
            {
                return NotFound();
            }

            return stretchfilmRI;
        }

        // PUT: api/StretchfilmRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStretchfilmRI(int id,StretchfilmRIDto stretchfilmRIDto)
        {
            StretchfilmRI stretchfilmRI = _mapper.Map<StretchfilmRI>(stretchfilmRIDto);
            stretchfilmRI.Id = id;
            stretchfilmRI.Created = await _context.QualityRIStretchfilm.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            stretchfilmRI.COA = await _context.QualityRIStretchfilm.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            stretchfilmRI.Modified = DateTime.Now;
            //stretchfilmRI.COA = _fileUploadLogic.UploadFile(stretchfilmRIDto.COA,"Quality", "Inspections\\Packaging\\Stretchfilms").Result;
            _context.Entry(stretchfilmRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StretchfilmRIExists(id))
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

        // POST: api/StretchfilmRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StretchfilmRI>> PostStretchfilmRI([FromForm] StretchfilmRIDto stretchfilmRIDto)
        {
            StretchfilmRI stretchfilmRI = _mapper.Map<StretchfilmRI>(stretchfilmRIDto);
            stretchfilmRI.Created = DateTime.Now;
            stretchfilmRI.Modified = stretchfilmRI.Created;
            stretchfilmRI.COA = _fileUploadLogic.UploadFile(stretchfilmRIDto.COA,"Quality","Inspections\\Packaging\\Stretchfilms").Result;
            _context.QualityRIStretchfilm.Add(stretchfilmRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStretchfilmRI", new { id = stretchfilmRI.Id }, stretchfilmRI);
        }

        // DELETE: api/StretchfilmRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StretchfilmRI>> DeleteStretchfilmRI(int id)
        {
            var stretchfilmRI = await _context.QualityRIStretchfilm.FindAsync(id);
            if (stretchfilmRI == null)
            {
                return NotFound();
            }

            _context.QualityRIStretchfilm.Remove(stretchfilmRI);
            await _context.SaveChangesAsync();

            return stretchfilmRI;
        }

        private bool StretchfilmRIExists(int id)
        {
            return _context.QualityRIStretchfilm.Any(e => e.Id == id);
        }
    }
}
