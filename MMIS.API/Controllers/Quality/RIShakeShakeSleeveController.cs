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


    public class RIShakeShakeSleeveController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIShakeShakeSleeveController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShakeShakeSleeve>>> GetShakeShakeSleeve(string Plant)
        {
            return await _context.QualityRIShakeShakeSleeve.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/ShakeShakeSleeves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShakeShakeSleeve>> GetShakeShakeSleeve(int id)
        {
            var labelRI = await _context.QualityRIShakeShakeSleeve.FindAsync(id);

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<ShakeShakeSleeve>> Get(string batch)
        {
            var labelRI = await _context.QualityRIShakeShakeSleeve.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }

        // PUT: api/ShakeShakeSleeves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShakeShakeSleeve(int id, ShakeShakeSleeveDto obj)
        {
            ShakeShakeSleeve labelRI = _mapper.Map<ShakeShakeSleeve>(obj);
            labelRI.Id = id;
            labelRI.Created = _context.QualityRIShakeShakeSleeve.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            labelRI.COA = _context.QualityRIShakeShakeSleeve.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            labelRI.Modified = DateTime.Now;
            //labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\Labels").Result;
            _context.Entry(labelRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShakeShakeSleeveExists(id))
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

        // POST: api/ShakeShakeSleeves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShakeShakeSleeve>> PostShakeShakeSleeve([FromForm] ShakeShakeSleeveDto obj)
        {
            ShakeShakeSleeve labelRI = _mapper.Map<ShakeShakeSleeve>(obj);
            labelRI.Created = DateTime.Now;
            labelRI.Modified = labelRI.Created;
            labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\ShakeShakeSleeve").Result;
            _context.QualityRIShakeShakeSleeve.Add(labelRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShakeShakeSleeve", new { id = labelRI.Id }, labelRI);
        }

        // DELETE: api/ShakeShakeSleeves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShakeShakeSleeve>> DeleteShakeShakeSleeve(int id)
        {
            var labelRI = await _context.QualityRIShakeShakeSleeve.FindAsync(id);
            if (labelRI == null)
            {
                return NotFound();
            }

            _context.QualityRIShakeShakeSleeve.Remove(labelRI);
            await _context.SaveChangesAsync();

            return labelRI;
        }

        private bool ShakeShakeSleeveExists(int id)
        {
            return _context.QualityRIShakeShakeSleeve.Any(e => e.Id == id);
        }
    }
}
