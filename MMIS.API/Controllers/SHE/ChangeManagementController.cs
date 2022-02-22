using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

    public class ChangeManagementController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;
        public ChangeManagementController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/ChangeManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeRequest>>> GetChangeManagement()
        {
            return await _context.ChangeRequest.ToListAsync();
        }

        // GET: api/ChangeManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeRequest>> GetChangeManagement(long id)
        {
            var changeRequest = await _context.ChangeRequest.FindAsync(id);

            if (changeRequest == null)
            {
                return NotFound();
            }

            return changeRequest;
        }

        // PUT: api/PreformRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeManagement(int id, ChangeRequest changeRequest)
        {
            //ChangeRequest data = _mapper.Map<ChangeRequest>(changeRequest);
            //data.Id = id;
            //data.DateModified = DateTime.Now;
            //  data.FilePath = _fileUploadLogic.UploadFile(changeRequest.files, "SHE", "ChangeRequest").Result;
            var data = changeRequest;
            _context.Attach(data);

            var entry = _context.Entry(data);
            entry.State = EntityState.Modified;
            entry.Property(e => e.FilePath).IsModified = false;
            entry.Property(e => e.Active).IsModified = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeManagementExists(id))
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

        // POST: api/ChangeManagement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChangeRequest>> PostChangeManagement([FromForm] ChangeManagementModel changeRequest)
        {
            ChangeRequest data = _mapper.Map<ChangeRequest>(changeRequest);
            data.FilePath = _fileUploadLogic.UploadFile(changeRequest.files, "SHE", "ChangeRequest").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
            _context.ChangeRequest.Add(data);
            
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetChangeManagement", new { id = data.Id }, data);
        }

        // DELETE: api/ChangeManagement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChangeRequest>> DeleteChangeManagement(int id)
        {
            var changeRequest = await _context.ChangeRequest.FindAsync(id);
            if (changeRequest == null)
            {
                return NotFound();
            }

            _context.ChangeRequest.Remove(changeRequest);
            await _context.SaveChangesAsync();

            return changeRequest;
        }

        private bool ChangeManagementExists(int id)
        {
            return _context.ChangeRequest.Any(e => e.Id == id);
        }
    }
}
