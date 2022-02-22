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


    public class RIMealieMealController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIMealieMealController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealieMealRI>>> GetMealieMeal(string Plant)
        {
            return await _context.QualityRIMealieMeal.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/MealieMeals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealieMealRI>> GetMealieMeal(int id)
        {
            var labelRI = await _context.QualityRIMealieMeal.FindAsync(id);

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<MealieMealRI>> Get(string batch)
        {
            var labelRI = await _context.QualityRIMealieMeal.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }

        // PUT: api/MealieMeals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealieMeal(int id, MealieMealRIDto obj)
        {
            MealieMealRI labelRI = _mapper.Map<MealieMealRI>(obj);
            labelRI.Id = id;
            labelRI.Created = _context.QualityRIMealieMeal.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            labelRI.COA = _context.QualityRIMealieMeal.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            labelRI.Modified = DateTime.Now;
            //labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\Labels").Result;
            _context.Entry(labelRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealieMealExists(id))
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

        // POST: api/MealieMeals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MealieMealRI>> PostMealieMeal([FromForm] MealieMealRIDto obj)
        {
            MealieMealRI labelRI = _mapper.Map<MealieMealRI>(obj);
            labelRI.Created = DateTime.Now;
            labelRI.Modified = labelRI.Created;
            labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality","Inspections\\Brewing\\MealieMeal").Result;
            _context.QualityRIMealieMeal.Add(labelRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealieMeal", new { id = labelRI.Id }, labelRI);
        }

        // DELETE: api/MealieMeals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MealieMealRI>> DeleteMealieMeal(int id)
        {
            var labelRI = await _context.QualityRIMealieMeal.FindAsync(id);
            if (labelRI == null)
            {
                return NotFound();
            }

            _context.QualityRIMealieMeal.Remove(labelRI);
            await _context.SaveChangesAsync();

            return labelRI;
        }

        private bool MealieMealExists(int id)
        {
            return _context.QualityRIMealieMeal.Any(e => e.Id == id);
        }
    }
}
