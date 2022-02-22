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


    public class RIShrinkfilmController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIShrinkfilmController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/ShrinkfilmRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ShrinkfilmRI>>> GetShrinkfilmRIs()
        //{
        //    return await _context.QualityRIShrinkfilm.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShrinkfilmRI>>> GetShrinkfilmRIs(string Plant)
        {
            return await _context.QualityRIShrinkfilm.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/ShrinkfilmRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShrinkfilmRI>> GetShrinkfilmRI(int id)
        {
            var shrinkfilmRI = await _context.QualityRIShrinkfilm.FindAsync(id);

            if (shrinkfilmRI == null)
            {
                return NotFound();
            }

            return shrinkfilmRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<ShrinkfilmRI>> GetShrinkfilmRI(string batch)
        {
            var shrinkfilmRI = await _context.QualityRIShrinkfilm.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (shrinkfilmRI == null)
            {
                return NotFound();
            }

            return shrinkfilmRI;
        }

        // PUT: api/ShrinkfilmRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShrinkfilmRI(int id,ShrinkfilmRIDto shrinkfilmRIDto)
        {
            ShrinkfilmRI shrinkfilmRI = _mapper.Map<ShrinkfilmRI>(shrinkfilmRIDto);
            shrinkfilmRI.Id = id;
            shrinkfilmRI.Created = _context.QualityRIShrinkfilm.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            shrinkfilmRI.COA = _context.QualityRIShrinkfilm.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            shrinkfilmRI.Modified = DateTime.Now;
            //shrinkfilmRI.COA = _fileUploadLogic.UploadFile(shrinkfilmRIDto.COA,"Quality", "Inspections\\Packaging\\Shrinkfilms").Result;
            _context.Entry(shrinkfilmRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShrinkfilmRIExists(id))
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

        // POST: api/ShrinkfilmRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShrinkfilmRI>> PostShrinkfilmRI([FromForm] ShrinkfilmRIDto shrinkfilmRIDto)
        {
            ShrinkfilmRI shrinkfilmRI = _mapper.Map<ShrinkfilmRI>(shrinkfilmRIDto);
            shrinkfilmRI.Created = DateTime.Now;
            shrinkfilmRI.Modified = shrinkfilmRI.Created;
            shrinkfilmRI.COA = _fileUploadLogic.UploadFile(shrinkfilmRIDto.COA,"Quality","Inspections\\Packaging\\Shrinkfilm").Result;
            _context.QualityRIShrinkfilm.Add(shrinkfilmRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShrinkfilmRI", new { id = shrinkfilmRI.Id }, shrinkfilmRI);
        }

        // DELETE: api/ShrinkfilmRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShrinkfilmRI>> DeleteShrinkfilmRI(int id)
        {
            var shrinkfilmRI = await _context.QualityRIShrinkfilm.FindAsync(id);
            if (shrinkfilmRI == null)
            {
                return NotFound();
            }

            _context.QualityRIShrinkfilm.Remove(shrinkfilmRI);
            await _context.SaveChangesAsync();

            return shrinkfilmRI;
        }

        private bool ShrinkfilmRIExists(int id)
        {
            return _context.QualityRIShrinkfilm.Any(e => e.Id == id);
        }
    }
}
