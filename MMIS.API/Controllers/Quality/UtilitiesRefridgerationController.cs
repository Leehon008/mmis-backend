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


    public class UtilitiesRefridgerationController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public UtilitiesRefridgerationController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Utilities
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Utilities>>> GetUtilities()
        //{
        //    return await _context.QualityUtilitiesRefridgeration.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refridgeration>>> GetRefridgeration(string Plant)
        {
            return await _context.QualityUtilitiesRefridgeration.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Id).ToListAsync();
        }

        // GET: api/Refridgeration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Refridgeration>> GetRefridgeration(int id)
        {
            var utilities = await _context.QualityUtilitiesRefridgeration.FindAsync(id);

            if (utilities == null)
            {
                return NotFound();
            }

            return utilities;
        }

        // PUT: api/Refridgeration/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefridgeration(int id, Refridgeration utilities)
        {
           
            utilities.Id = id;
            utilities.Created = _context.QualityUtilitiesRefridgeration.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
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
                if (!RefridgerationExists(id))
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

        // POST: api/Refridgeration
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Refridgeration>> PostRefridgeration(Refridgeration utilities)
        {
        
            utilities.Created = DateTime.Now;
            utilities.Modified = utilities.Created;
            _context.QualityUtilitiesRefridgeration.Add(utilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefridgeration", new { id = utilities.Id }, utilities);
        }

        // DELETE: api/Refridgeration/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Refridgeration>> DeleteRefridgeration(int id)
        {
            var utilities = await _context.QualityUtilitiesRefridgeration.FindAsync(id);
            if (utilities == null)
            {
                return NotFound();
            }

            _context.QualityUtilitiesRefridgeration.Remove(utilities);
            await _context.SaveChangesAsync();

            return utilities;
        }

        private bool RefridgerationExists(int id)
        {
            return _context.QualityUtilitiesRefridgeration.Any(e => e.Id == id);
        }
    }
}
