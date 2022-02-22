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

//
    public class WortController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public WortController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Worts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Wort>>> GetWorts()
        //{
        //    return await _context.QualityWort.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wort>>> GetWorts(string Plant)
        {
            return await _context.QualityWort.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Worts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wort>> GetWort(int id)
        {
            var wort = await _context.QualityWort.FindAsync(id);

            if (wort == null)
            {
                return NotFound();
            }

            return wort;
        }

        // PUT: api/Worts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWort(int id, WortDto wortDto)
        {
            Wort wort = _mapper.Map<Wort>(wortDto);
            wort.Id = id;
            wort.Created = _context.QualityWort.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            wort.Modified = DateTime.Now;
            _context.Entry(wort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WortExists(id))
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

        // POST: api/Worts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wort>> PostWort(WortDto wortDto)
        {
            Wort wort = _mapper.Map<Wort>(wortDto);
            wort.Created = DateTime.Now;
            wort.Modified = wort.Created;
            _context.QualityWort.Add(wort);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWort", new { id = wort.Id }, wort);
        }

        // DELETE: api/Worts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wort>> DeleteWort(int id)
        {
            var wort = await _context.QualityWort.FindAsync(id);
            if (wort == null)
            {
                return NotFound();
            }

            _context.QualityWort.Remove(wort);
            await _context.SaveChangesAsync();

            return wort;
        }

        private bool WortExists(int id)
        {
            return _context.QualityWort.Any(e => e.Id == id);
        }
    }
}
