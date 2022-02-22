﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.UtilitiesEng.Entities;

namespace MMIS.API.Controllers.UtilitiesEng
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class IQMSController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public IQMSController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/IQMS
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<IQMS>>> Get()
        //{
        //    return await _context.UtilitiesIQMS.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<IQMS>>> GetList(string Plant)
        {
            return await _context.UtilitiesIQMS.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/IQMS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IQMS>> Get(int id)
        {
            var obj = await _context.UtilitiesIQMS.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/IQMS/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IQMS obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;
            //_context.Entry(obj).State = EntityState.Modified;
            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;


            foreach (var navigationProperty in obj.WaterParameters.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.UtilitiesIQMS.Find(obj.Id)
                        .WaterParameters.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            //_context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IQMSExists(id))
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

        // POST: api/IQMS
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IQMS>> Post(IQMS obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.UtilitiesIQMS.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/IQMS/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IQMS>> Delete(int id)
        {
            var obj = await _context.UtilitiesIQMS.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.UtilitiesIQMS.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool IQMSExists(int id)
        {
            return _context.UtilitiesIQMS.Any(e => e.Id == id);
        }
    }
}
