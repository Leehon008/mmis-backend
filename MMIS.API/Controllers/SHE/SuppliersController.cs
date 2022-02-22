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
using MMIS.DomainLayer.Quality.Entities;
using MMIS.DomainLayer.Quality.Models;
using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.API.Controllers.SHE
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class SupplierController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public SupplierController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Supplierss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suppliers>>> GetSupplier()
        {
            return await _context.Suppliers.ToListAsync();
        }

        // GET: api/Supplierss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suppliers>> GetSupplier(int id)
        {
            var suppliers = await _context.Suppliers.FindAsync(id);

            if (suppliers == null)
            {
                return NotFound();
            }

            return suppliers;
        }
    

        // PUT: api/Supplierss/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuppliers(int id, [FromForm] SuppliersDto suppliersDto)
        {
            Suppliers suppliers = _mapper.Map<Suppliers>(suppliersDto);
            suppliers.Id = id;
            suppliers.DateCreated = await _context.Suppliers.Where(m => m.Id == id).Select(m => m.DateCreated).FirstOrDefaultAsync();
            suppliers.FilePath = await _context.Suppliers.Where(m => m.Id == id).Select(m => m.FilePath).FirstOrDefaultAsync();
            suppliers.DateModified = DateTime.Now;
            //suppliers.COA = _fileUploadLogic.UploadFile(suppliersDto.COA,"Quality", "Inspections\\Packaging\\Closures").Result;
            _context.Entry(suppliers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuppierExists(id))
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

        // POST: api/Supplierss
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Suppliers>> PostSupplier([FromForm] SuppliersDto suppliersDto)
        {
            Suppliers suppliers = _mapper.Map<Suppliers>(suppliersDto);
            suppliers.DateCreated = DateTime.Now;
            suppliers.DateModified = suppliers.DateCreated;
            suppliers.FilePath = _fileUploadLogic.UploadFile(suppliersDto.files,"SHE","Suppliers").Result;
            _context.Suppliers.Add(suppliers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = suppliers.Id }, suppliers);
        }

        // DELETE: api/Supplierss/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suppliers>> DeleteSuppliers(int id)
        {
            var suppliers = await _context.Suppliers.FindAsync(id);
            if (suppliers == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(suppliers);
            await _context.SaveChangesAsync();

            return suppliers;
        }

        private bool SuppierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
