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


    public class RIGlueController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIGlueController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/GlueRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<GlueRI>>> GetGlueRIs()
        //{
        //    return await _context.QualityRIGlue.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlueRI>>> GetGlueRIs(string Plant)
        {
            return await _context.QualityRIGlue.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/GlueRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlueRI>> GetGlueRI(int id)
        {
            var glueRI = await _context.QualityRIGlue.FindAsync(id);

            if (glueRI == null)
            {
                return NotFound();
            }

            return glueRI;
        }

        [HttpGet("{batch}")]

        public async Task<ActionResult<GlueRI>> GetGlueRI(string batch)
        {
            var glueRI = await _context.QualityRIGlue.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (glueRI == null)
            {
                return NotFound();
            }

            return glueRI;
        }

        // PUT: api/GlueRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlueRI(int id,GlueRIDto glueRIDto)
        {
            GlueRI glueRI = _mapper.Map<GlueRI>(glueRIDto);
            glueRI.Id = id;
            glueRI.Created = _context.QualityRIGlue.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            glueRI.COA = _context.QualityRIGlue.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            glueRI.Modified = DateTime.Now;
            //glueRI.COA = _fileUploadLogic.UploadFile(glueRIDto.COA,"Quality", "Inspections\\Packaging\\Glues").Result;
            _context.Entry(glueRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlueRIExists(id))
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

        // POST: api/GlueRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GlueRI>> PostGlueRI([FromForm] GlueRIDto glueRIDto)
        {
            GlueRI glueRI = _mapper.Map<GlueRI>(glueRIDto);
            glueRI.Created = DateTime.Now;
            glueRI.Modified = glueRI.Created;
            glueRI.COA = _fileUploadLogic.UploadFile(glueRIDto.COA,"Quality","Inspections\\Packaging\\Glue").Result;
            _context.QualityRIGlue.Add(glueRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGlueRI", new { id = glueRI.Id }, glueRI);
        }

        // DELETE: api/GlueRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GlueRI>> DeleteGlueRI(int id)
        {
            var glueRI = await _context.QualityRIGlue.FindAsync(id);
            if (glueRI == null)
            {
                return NotFound();
            }

            _context.QualityRIGlue.Remove(glueRI);
            await _context.SaveChangesAsync();

            return glueRI;
        }

        private bool GlueRIExists(int id)
        {
            return _context.QualityRIGlue.Any(e => e.Id == id);
        }
    }
}
