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
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class ChangeRequestsController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public ChangeRequestsController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/ChangeRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeRequest>>> GetChangeRequest()
        {
            return await _context.ChangeRequest.ToListAsync();
        }

        // GET: api/ChangeRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeRequest>> GetChangeRequest(int id)
        {
            var changeRequest = await _context.ChangeRequest.FindAsync(id);

            if (changeRequest == null)
            {
                return NotFound();
            }

            return changeRequest;
        }

        // PUT: api/ChangeRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeRequest(int id, ChangeRequest changeRequest)
        {
            if (id != changeRequest.Id)
            {
                return BadRequest();
            }
            changeRequest.DateModified = DateTime.Now;
            _context.Entry(changeRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeRequestExists(id))
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

        // POST: api/ChangeRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Appointments>> PostChangeRequest([FromForm] ChangeRequestDto changeRequestDto)
        {
            ChangeRequest data = _mapper.Map<ChangeRequest>(changeRequestDto);
            data.FilePath = _fileUploadLogic.UploadFile(changeRequestDto.files, "SHE", "ChangeRequest").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChangeRequest", new { id = data.Id }, data);
        }

        // DELETE: api/ChangeRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChangeRequest>> DeleteChangeRequest(int id)
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

        private bool ChangeRequestExists(int id)
        {
            return _context.ChangeRequest.Any(e => e.Id == id);
        }
    }
}
