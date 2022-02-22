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


    public class RIMaizeController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RIMaizeController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/MaizeRIs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaizeRI>>> GetMaizeRIs()
        //{
        //    return await _context.QualityRIMaize.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaizeRI>>> GetMaizeRIs(string Plant)
        {
            return await _context.QualityRIMaize.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/MaizeRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaizeRI>> GetMaizeRI(int id)
        {
            var maizeRI = await _context.QualityRIMaize.FindAsync(id);

            if (maizeRI == null)
            {
                return NotFound();
            }

            return maizeRI;
        }

        // PUT: api/MaizeRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaizeRI(int id,MaizeRIDto maizeRIDto)
        {
            MaizeRI maizeRI = _mapper.Map<MaizeRI>(maizeRIDto);
            maizeRI.Id = id;
            maizeRI.Created = _context.QualityRIMaize.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            maizeRI.Modified = DateTime.Now;
            //maizeRI.COA = _fileUploadLogic.UploadFile(maizeRIDto.COA, "Quality", "Inspections\\Brewing\\Maize").Result;
            _context.Entry(maizeRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaizeRIExists(id))
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

        // POST: api/MaizeRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaizeRI>> PostMaizeRI([FromForm] MaizeRIDto maizeRIDto)
        {
            MaizeRI maizeRI = _mapper.Map<MaizeRI>(maizeRIDto);
            maizeRI.Created = DateTime.Now;
            maizeRI.Modified = maizeRI.Created;
            _context.QualityRIMaize.Add(maizeRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaizeRI", new { id = maizeRI.Id }, maizeRI);
        }

        // DELETE: api/MaizeRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaizeRI>> DeleteMaizeRI(int id)
        {
            var maizeRI = await _context.QualityRIMaize.FindAsync(id);
            if (maizeRI == null)
            {
                return NotFound();
            }

            _context.QualityRIMaize.Remove(maizeRI);
            await _context.SaveChangesAsync();

            return maizeRI;
        }

        private bool MaizeRIExists(int id)
        {
            return _context.QualityRIMaize.Any(e => e.Id == id);
        }
    }
}
