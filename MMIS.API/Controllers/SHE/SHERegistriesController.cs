using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.SHE.Contract;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class SHERegistriesController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public SHERegistriesController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/SHERegistries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SHERegistry>>> GetSHERegistry()
        {
            return await _context.SHERegistry.ToListAsync();
        }

        // GET: api/SHERegistries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SHERegistry>> GetSHERegistry(int id)
        {
            var sHERegistry = await _context.SHERegistry.FindAsync(id);

            if (sHERegistry == null)
            {
                return NotFound();
            }

            return sHERegistry;
        }

        // PUT: api/SHERegistries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSHERegistry(int id, SHERegistry sHERegistry)
        {
            if (id != sHERegistry.Id)
            {
                return BadRequest();
            }
            sHERegistry.DateModified = DateTime.Now;

            _context.Entry(sHERegistry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SHERegistryExists(id))
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

        // POST: api/SHERegistries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SHERegistry>> PostSHERegistry(SHERegistry sHERegistry)
        {
            SHERegistry data = _mapper.Map<SHERegistry>(sHERegistry);
           // data.Path = _fileUploadLogic.UploadFile(sHERegistry.files, "SHE", "SHERegistry").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
            _context.SHERegistry.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSHERegistry", new { id = data.Id }, data);
        }

        // DELETE: api/SHERegistries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SHERegistry>> DeleteSHERegistry(int id)
        {
            var sHERegistry = await _context.SHERegistry.FindAsync(id);
            if (sHERegistry == null)
            {
                return NotFound();
            }

            _context.SHERegistry.Remove(sHERegistry);
            await _context.SaveChangesAsync();

            return sHERegistry;
        }

        private bool SHERegistryExists(int id)
        {
            return _context.SHERegistry.Any(e => e.Id == id);
        }
    }
}
