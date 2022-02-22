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


    public class RIScudBottleController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIScudBottleController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/ScudBottleRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ScudBottleRI>>> GetScudBottleRIs()
        //{
        //    return await _context.QualityRIScudBottle.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScudBottleRI>>> GetScudBottleRIs(string Plant)
        {
            return await _context.QualityRIScudBottle.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/ScudBottleRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScudBottleRI>> GetScudBottleRI(int id)
        {
            var bottleRI = await _context.QualityRIScudBottle.FindAsync(id);

            if (bottleRI == null)
            {
                return NotFound();
            }

            return bottleRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<ScudBottleRI>> GetScudBottleRI(string batch)
        {
            var bottleRI = await _context.QualityRIScudBottle.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (bottleRI == null)
            {
                return NotFound();
            }

            return bottleRI;
        }

        // PUT: api/ScudBottleRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScudBottleRI(int id,ScudBottleRIDto bottleRIDto)
        {
            ScudBottleRI bottleRI = _mapper.Map<ScudBottleRI>(bottleRIDto);
            bottleRI.Id = id;
            bottleRI.Created = await _context.QualityRIScudBottle.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            bottleRI.COA = await _context.QualityRIScudBottle.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            bottleRI.Modified = DateTime.Now;
            //bottleRI.COA = _fileUploadLogic.UploadFile(bottleRIDto.COA,"Quality", "Inspections\\Packaging\\ScudBottles").Result;
            _context.Entry(bottleRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScudBottleRIExists(id))
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

        // POST: api/ScudBottleRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScudBottleRI>> PostScudBottleRI([FromForm] ScudBottleRIDto bottleRIDto)
        {
            ScudBottleRI bottleRI = _mapper.Map<ScudBottleRI>(bottleRIDto);
            bottleRI.Created = DateTime.Now;
            bottleRI.Modified = bottleRI.Created;
            bottleRI.COA = _fileUploadLogic.UploadFile(bottleRIDto.COA,"Quality","Inspections\\Packaging\\ScudBottles").Result;
            _context.QualityRIScudBottle.Add(bottleRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScudBottleRI", new { id = bottleRI.Id }, bottleRI);
        }

        // DELETE: api/ScudBottleRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScudBottleRI>> DeleteScudBottleRI(int id)
        {
            var bottleRI = await _context.QualityRIScudBottle.FindAsync(id);
            if (bottleRI == null)
            {
                return NotFound();
            }

            _context.QualityRIScudBottle.Remove(bottleRI);
            await _context.SaveChangesAsync();

            return bottleRI;
        }

        private bool ScudBottleRIExists(int id)
        {
            return _context.QualityRIScudBottle.Any(e => e.Id == id);
        }
    }
}
