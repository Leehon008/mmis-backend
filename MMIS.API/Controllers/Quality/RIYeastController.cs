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


    public class RIYeastController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIYeastController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }


        // GET: api/YeastRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<YeastRI>>> GetYeastRIs()
        //{
        //    return await _context.QualityRIYeast.ToListAsync();
        //}

        // GET: api/YeastRIs

        [HttpGet]
        public async Task<ActionResult<IEnumerable<YeastRI>>> GetYeastRIs(string Plant)
        {
            return await _context.QualityRIYeast.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/YeastRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YeastRI>> GetYeastRI(int id)
        {
            var yeastRI = await _context.QualityRIYeast.FindAsync(id);

            if (yeastRI == null)
            {
                return NotFound();
            }

            return yeastRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<YeastRI>> GetYeastRI(string batch)
        {
            var yeastRI = await _context.QualityRIYeast.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (yeastRI == null)
            {
                return NotFound();
            }

            return yeastRI;
        }

        // PUT: api/YeastRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYeastRI(int id,YeastRIDto yeastRIDto)
        {
            YeastRI yeastRI = _mapper.Map<YeastRI>(yeastRIDto);
            yeastRI.Id = id;
            yeastRI.Created = await _context.QualityRIYeast.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefaultAsync();
            yeastRI.COA = await _context.QualityRIYeast.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefaultAsync();
            yeastRI.Modified = DateTime.Now;
            //yeastRI.COA = _fileUploadLogic.UploadFile(yeastRIDto.COA, "Quality", "Inspections\\Brewing\\Yeast").Result;

            _context.Entry(yeastRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YeastRIExists(id))
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

        // POST: api/YeastRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<YeastRI>> PostYeastRI([FromForm] YeastRIDto yeastRIDto)
        {
            YeastRI yeastRI = _mapper.Map<YeastRI>(yeastRIDto);
            yeastRI.Created = DateTime.Now;
            yeastRI.Modified = yeastRI.Created;
            yeastRI.COA = _fileUploadLogic.UploadFile(yeastRIDto.COA, "Quality", "Inspections\\Brewing\\Yeast").Result;
            _context.QualityRIYeast.Add(yeastRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYeastRI", new { id = yeastRI.Id }, yeastRI);
        }

        // DELETE: api/YeastRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YeastRI>> DeleteYeastRI(int id)
        {
            var yeastRI = await _context.QualityRIYeast.FindAsync(id);
            if (yeastRI == null)
            {
                return NotFound();
            }

            _context.QualityRIYeast.Remove(yeastRI);
            await _context.SaveChangesAsync();

            return yeastRI;
        }

        private bool YeastRIExists(int id)
        {
            return _context.QualityRIYeast.Any(e => e.Id == id);
        }
    }
}
