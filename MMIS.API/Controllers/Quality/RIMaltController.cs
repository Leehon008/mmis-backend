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


    public class RIMaltController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIMaltController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/MaltRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaltRI>>> GetMaltRIs()
        //{
        //    return await _context.QualityRIMalt.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaltRI>>> GetMaltRIs(string Plant)
        {
            return await _context.QualityRIMalt.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/MaltRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaltRI>> GetMaltRI(int id)
        {
            var maltRI = await _context.QualityRIMalt.FindAsync(id);

            if (maltRI == null)
            {
                return NotFound();
            }

            return maltRI;
        }

        [HttpGet("{batch}")]

        public async Task<ActionResult<MaltRI>> GetMaltRI(string batch)
        {
            var maltRI = await _context.QualityRIMalt.Where(m => m.BatchNo == batch).FirstOrDefaultAsync(); 

            if (maltRI == null)
            {
                return NotFound();
            }

            return maltRI;
        }

        // PUT: api/MaltRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaltRI(int id,MaltRIDto maltRIDto)
        {
            MaltRI maltRI = _mapper.Map<MaltRI>(maltRIDto);
            maltRI.Id = id;
            maltRI.Created = await _context.QualityRIMalt.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            maltRI.COA = await _context.QualityRIMalt.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            maltRI.Modified = DateTime.Now;
            //maltRI.COA = _fileUploadLogic.UploadFile(maltRIDto.COA, "Quality", "Inspections\\Brewing\\Malt").Result;

            _context.Entry(maltRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaltRIExists(id))
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

        // POST: api/MaltRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaltRI>> PostMaltRI([FromForm] MaltRIDto maltRIDto)
        {
            MaltRI maltRI = _mapper.Map<MaltRI>(maltRIDto);
            maltRI.Created = DateTime.Now;
            maltRI.Modified = maltRI.Created;
            maltRI.COA = _fileUploadLogic.UploadFile(maltRIDto.COA, "Quality", "Inspections\\Brewing\\Malt").Result;
            _context.QualityRIMalt.Add(maltRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaltRI", new { id = maltRI.Id }, maltRI);
        }

        // DELETE: api/MaltRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaltRI>> DeleteMaltRI(int id)
        {
            var maltRI = await _context.QualityRIMalt.FindAsync(id);
            if (maltRI == null)
            {
                return NotFound();
            }

            _context.QualityRIMalt.Remove(maltRI);
            await _context.SaveChangesAsync();

            return maltRI;
        }

        private bool MaltRIExists(int id)
        {
            return _context.QualityRIMalt.Any(e => e.Id == id);
        }
    }
}
