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


    public class UtilitiesBoilerController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public UtilitiesBoilerController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Utilities
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Utilities>>> GetUtilities()
        //{
        //    return await _context.QualityUtilitiesBoiler.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boiler>>> GetBoiler(string Plant)
        {
            return await _context.QualityUtilitiesBoiler.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Id).ToListAsync();
        }

        // GET: api/Boiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boiler>> GetBoiler(int id)
        {
            var utilities = await _context.QualityUtilitiesBoiler.FindAsync(id);

            if (utilities == null)
            {
                return NotFound();
            }

            return utilities;
        }

        // PUT: api/Boiler/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoiler(int id, Boiler utilities)
        {
           
            utilities.Id = id;
            utilities.Created = _context.QualityUtilitiesBoiler.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            utilities.Modified = DateTime.Now;
            //_context.Entry(utilities).State = EntityState.Modified;
            _context.Attach(utilities);

            var entry = _context.Entry(utilities);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoilerExists(id))
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

        // POST: api/Boiler
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Boiler>> PostBoiler(Boiler utilities)
        {
        
            utilities.Created = DateTime.Now;
            utilities.Modified = utilities.Created;
            _context.QualityUtilitiesBoiler.Add(utilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoiler", new { id = utilities.Id }, utilities);
        }

        // DELETE: api/Boiler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boiler>> DeleteBoiler(int id)
        {
            var utilities = await _context.QualityUtilitiesBoiler.FindAsync(id);
            if (utilities == null)
            {
                return NotFound();
            }

            _context.QualityUtilitiesBoiler.Remove(utilities);
            await _context.SaveChangesAsync();

            return utilities;
        }

        private bool BoilerExists(int id)
        {
            return _context.QualityUtilitiesBoiler.Any(e => e.Id == id);
        }
    }
}
