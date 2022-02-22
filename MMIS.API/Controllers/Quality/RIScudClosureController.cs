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


    public class RIScudClosureController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIScudClosureController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/ScudClosureRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ScudClosureRI>>> GetScudClosureRIs()
        //{
        //    return await _context.QualityRIScudClosure.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScudClosureRI>>> GetScudClosureRIs(string Plant)
        {
            return await _context.QualityRIScudClosure.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/ScudClosureRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScudClosureRI>> GetScudClosureRI(int id)
        {
            var closureRI = await _context.QualityRIScudClosure.FindAsync(id);

            if (closureRI == null)
            {
                return NotFound();
            }

            return closureRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<ScudClosureRI>> GetScudClosureRI(string batch)
        {
            var closureRI = await _context.QualityRIScudClosure.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (closureRI == null)
            {
                return NotFound();
            }

            return closureRI;
        }

        // PUT: api/ScudClosureRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScudClosureRI(int id,ScudClosureRIDto closureRIDto)
        {
            ScudClosureRI closureRI = _mapper.Map<ScudClosureRI>(closureRIDto);
            closureRI.Id = id;
            closureRI.Created = await _context.QualityRIScudClosure.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            closureRI.COA = await _context.QualityRIScudClosure.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            closureRI.Modified = DateTime.Now;
            //closureRI.COA = _fileUploadLogic.UploadFile(closureRIDto.COA,"Quality", "Inspections\\Packaging\\ScudClosures").Result;
            _context.Entry(closureRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScudClosureRIExists(id))
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

        // POST: api/ScudClosureRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScudClosureRI>> PostScudClosureRI([FromForm] ScudClosureRIDto closureRIDto)
        {
            ScudClosureRI closureRI = _mapper.Map<ScudClosureRI>(closureRIDto);
            closureRI.Created = DateTime.Now;
            closureRI.Modified = closureRI.Created;
            closureRI.COA = _fileUploadLogic.UploadFile(closureRIDto.COA,"Quality","Inspections\\Packaging\\ScudClosures").Result;
            _context.QualityRIScudClosure.Add(closureRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScudClosureRI", new { id = closureRI.Id }, closureRI);
        }

        // DELETE: api/ScudClosureRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScudClosureRI>> DeleteScudClosureRI(int id)
        {
            var closureRI = await _context.QualityRIScudClosure.FindAsync(id);
            if (closureRI == null)
            {
                return NotFound();
            }

            _context.QualityRIScudClosure.Remove(closureRI);
            await _context.SaveChangesAsync();

            return closureRI;
        }

        private bool ScudClosureRIExists(int id)
        {
            return _context.QualityRIScudClosure.Any(e => e.Id == id);
        }
    }
}
