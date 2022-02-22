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

    public class AppointmentsController : ControllerBase
    {
        private readonly MMISDbContext _context;
        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;
        public AppointmentsController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Appointments1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointments()
        {
            return await _context.SHEAppointments.ToListAsync();
        }

        // GET: api/Appointments1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointments>> GetAppointments(long id)
        {
            var appointments = await _context.SHEAppointments.FindAsync(id);

            if (appointments == null)
            {
                return NotFound();
            }

            return appointments;
        }

        // PUT: api/PreformRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointments(int id, Appointments appointments)
        {
            //Appointments data = _mapper.Map<Appointments>(appointments);
            //data.Id = id;
            //data.DateModified = DateTime.Now;
            //  data.AppointmentLetter = _fileUploadLogic.UploadFile(appointments.files, "SHE", "Appointments").Result;
            var data = appointments;
            _context.Attach(data);

            var entry = _context.Entry(data);
            entry.State = EntityState.Modified;
            entry.Property(e => e.AppointmentLetter).IsModified = false;
            entry.Property(e => e.Active).IsModified = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentsExists(id))
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

        // POST: api/Appointments1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Appointments>> PostAppointments([FromForm] AppointmentsModel appointments)
        {
            Appointments data = _mapper.Map<Appointments>(appointments);
            data.AppointmentLetter = _fileUploadLogic.UploadFile(appointments.files, "SHE", "Appointments").Result;
            data.DateCreated = DateTime.Now;
            data.DateModified = DateTime.Now;
            data.Active = true;
            _context.SHEAppointments.Add(data);
            
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetAppointments", new { id = data.Id }, data);
        }

        // DELETE: api/Appointments1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointments>> DeleteAppointments(int id)
        {
            var appointments = await _context.SHEAppointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }

            _context.SHEAppointments.Remove(appointments);
            await _context.SaveChangesAsync();

            return appointments;
        }

        private bool AppointmentsExists(int id)
        {
            return _context.SHEAppointments.Any(e => e.Id == id);
        }
    }
}
