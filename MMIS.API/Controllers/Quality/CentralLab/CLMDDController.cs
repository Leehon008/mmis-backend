﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.CentralLab.Entities;

namespace MMIS.API.Controllers.Quality
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class CLMDDController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public CLMDDController(MMISDbContext context)
        {
            _context = context;
        }

        // GET: api/CLMDD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLMDD>>> GetQualityCLMDD()
        {
            return await _context.QualityCLMDD.ToListAsync();
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CLMDD>>> GetQualityCLMDD(string Plant)
        //{
        //    return await _context.QualityCLMDD.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        //}

        // GET: api/CLMDD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CLMDD>> GetCLMDD(int id)
        {
            var obj = await _context.QualityCLMDD.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/CLMDD/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCLMDD(int id, CLMDD obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }
            obj.Modified = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLMDDExists(id))
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

        // POST: api/CLMDD
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CLMDD>> PostCLMDD(CLMDD obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;
            _context.QualityCLMDD.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCLMDD", new { id = obj.Id }, obj);
        }

        // DELETE: api/CLMDD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CLMDD>> DeleteCLMDD(int id)
        {
            var obj = await _context.QualityCLMDD.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.QualityCLMDD.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool CLMDDExists(int id)
        {
            return _context.QualityCLMDD.Any(e => e.Id == id);
        }
    }
}
