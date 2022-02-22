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


    public class CustomerComplaintController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public CustomerComplaintController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/CustomerComplaints
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CustomerComplaint>>> GetCustomerComplaints()
        //{
        //    return await _context.QualityCustomerComplaint.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerComplaint>>> GetCustomerComplaints(string Plant)
        {
            return await _context.QualityCustomerComplaint.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/CustomerComplaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerComplaint>> GetCustomerComplaint(int id)
        {
            var customerComplaint = await _context.QualityCustomerComplaint.FindAsync(id);

            if (customerComplaint == null)
            {
                return NotFound();
            }

            return customerComplaint;
        }

        // PUT: api/CustomerComplaints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerComplaint(int id, CustomerComplaintDto customerComplaintDto)
        {
            CustomerComplaint customerComplaint = _mapper.Map<CustomerComplaint>(customerComplaintDto);
            customerComplaint.Id = id;
            customerComplaint.Created = _context.QualityCustomerComplaint.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            customerComplaint.Modified = DateTime.Now;
            _context.Entry(customerComplaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerComplaintExists(id))
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

        // POST: api/CustomerComplaints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerComplaint>> PostCustomerComplaint(CustomerComplaintDto customerComplaintDto)
        {
            CustomerComplaint customerComplaint = _mapper.Map<CustomerComplaint>(customerComplaintDto);
            customerComplaint.Created = DateTime.Now;
            customerComplaint.Modified = customerComplaint.Created;
            _context.QualityCustomerComplaint.Add(customerComplaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerComplaint", new { id = customerComplaint.Id }, customerComplaint);
        }

        // DELETE: api/CustomerComplaints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerComplaint>> DeleteCustomerComplaint(int id)
        {
            var customerComplaint = await _context.QualityCustomerComplaint.FindAsync(id);
            if (customerComplaint == null)
            {
                return NotFound();
            }

            _context.QualityCustomerComplaint.Remove(customerComplaint);
            await _context.SaveChangesAsync();

            return customerComplaint;
        }

        private bool CustomerComplaintExists(int id)
        {
            return _context.QualityCustomerComplaint.Any(e => e.Id == id);
        }
    }
}
