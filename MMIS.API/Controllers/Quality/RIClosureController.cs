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


    public class RIClosureController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIClosureController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/ClosureRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ClosureRI>>> GetClosureRIs()
        //{
        //    return await _context.QualityRIClosure.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClosureRI>>> GetClosureRIs(string Plant)
        {
            return await _context.QualityRIClosure.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/ClosureRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClosureRI>> GetClosureRI(int id)
        {
            var closureRI = await _context.QualityRIClosure.FindAsync(id);

            if (closureRI == null)
            {
                return NotFound();
            }

            return closureRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<ClosureRI>> GetClosureRI(string batch)
        {
            var closureRI = await _context.QualityRIClosure.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (closureRI == null)
            {
                return NotFound();
            }

            return closureRI;
        }

        // PUT: api/ClosureRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClosureRI(int id,ClosureRIDto closureRIDto)
        {
            ClosureRI closureRI = _mapper.Map<ClosureRI>(closureRIDto);
            closureRI.Id = id;
            closureRI.Created = await _context.QualityRIClosure.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            closureRI.COA = await _context.QualityRIClosure.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            closureRI.Modified = DateTime.Now;
            //closureRI.COA = _fileUploadLogic.UploadFile(closureRIDto.COA,"Quality", "Inspections\\Packaging\\Closures").Result;
            _context.Entry(closureRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClosureRIExists(id))
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

        // POST: api/ClosureRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClosureRI>> PostClosureRI([FromForm] ClosureRIDto closureRIDto)
        {
            ClosureRI closureRI = _mapper.Map<ClosureRI>(closureRIDto);
            closureRI.Created = DateTime.Now;
            closureRI.Modified = closureRI.Created;
            closureRI.COA = _fileUploadLogic.UploadFile(closureRIDto.COA,"Quality","Inspections\\Packaging\\Closures").Result;
            _context.QualityRIClosure.Add(closureRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClosureRI", new { id = closureRI.Id }, closureRI);
        }

        // DELETE: api/ClosureRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClosureRI>> DeleteClosureRI(int id)
        {
            var closureRI = await _context.QualityRIClosure.FindAsync(id);
            if (closureRI == null)
            {
                return NotFound();
            }

            _context.QualityRIClosure.Remove(closureRI);
            await _context.SaveChangesAsync();

            return closureRI;
        }

        private bool ClosureRIExists(int id)
        {
            return _context.QualityRIClosure.Any(e => e.Id == id);
        }
    }
}
