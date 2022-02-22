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


    public class RILabelController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RILabelController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/LabelRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<GlueRI>>> GetGlueRIs()
        //{
        //    return await _context.QualityRIGlue.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabelRI>>> GetGlueRIs(string Plant)
        {
            return await _context.QualityRILabel.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/LabelRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabelRI>> GetLabelRI(int id)
        {
            var labelRI = await _context.QualityRILabel.FindAsync(id);

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<LabelRI>> GetLabelRI(string batch)
        {
            var labelRI = await _context.QualityRILabel.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }

        // PUT: api/LabelRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabelRI(int id,LabelRIDto labelRIDto)
        {
            LabelRI labelRI = _mapper.Map<LabelRI>(labelRIDto);
            labelRI.Id = id;
            labelRI.Created = _context.QualityRILabel.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            labelRI.COA = _context.QualityRILabel.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            labelRI.Modified = DateTime.Now;
            //labelRI.COA = _fileUploadLogic.UploadFile(labelRIDto.COA,"Quality", "Inspections\\Packaging\\Labels").Result;
            _context.Entry(labelRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabelRIExists(id))
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

        // POST: api/LabelRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LabelRI>> PostLabelRI([FromForm] LabelRIDto labelRIDto)
        {
            LabelRI labelRI = _mapper.Map<LabelRI>(labelRIDto);
            labelRI.Created = DateTime.Now;
            labelRI.Modified = labelRI.Created;
            labelRI.COA = _fileUploadLogic.UploadFile(labelRIDto.COA,"Quality","Inspections\\Packaging\\Labels").Result;
            _context.QualityRILabel.Add(labelRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabelRI", new { id = labelRI.Id }, labelRI);
        }

        // DELETE: api/LabelRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LabelRI>> DeleteLabelRI(int id)
        {
            var labelRI = await _context.QualityRILabel.FindAsync(id);
            if (labelRI == null)
            {
                return NotFound();
            }

            _context.QualityRILabel.Remove(labelRI);
            await _context.SaveChangesAsync();

            return labelRI;
        }

        private bool LabelRIExists(int id)
        {
            return _context.QualityRILabel.Any(e => e.Id == id);
        }
    }
}
