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

    public class HourlyUsageSteamController : ControllerBase
    {
        private readonly MMISDbContext _context;

        public HourlyUsageSteamController(MMISDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourlyUsageSteam>>> GetList(string Plant)
        {
            return await _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/HourlyUsageSteam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HourlyUsageSteam>> Get(int id)
        {
            var obj = await _context.UtilitiesHourlyUsageSteam.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // GET: api/HourlyUsageSteam/5
        [HttpGet("{plant}/{date}")]
        public ActionResult<HourlyUsageSteam> GetPrevious(string plant, DateTime date, int hour)
        {
            HourlyUsageSteam oldObj;

            if (hour != 0)
            {
                if (hour > 1)
                {
                    oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Equals(plant) && m.Date == date && m.Hour == (hour - 1)).FirstOrDefault();
                }
                else
                {
                    oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Equals(plant) && m.Date == (date.AddDays(-1))).OrderByDescending(m => m.Hour).FirstOrDefault();
                }
            }
            else
            {
                oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Equals(plant) && m.Date == (date.AddDays(-1))).FirstOrDefault();
            }

            if (oldObj == null)
            {
                return NotFound();
            }

            return oldObj;
        }



        // PUT: api/HourlyUsageSteam/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, HourlyUsageSteam obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            obj.Modified = DateTime.Now;

            obj = Calculate(obj);

            _context.Attach(obj);

            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Created).IsModified = false;

            foreach (var navigationProperty in obj.Readings.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.UtilitiesHourlyUsageSteam.Find(obj.Id)
                        .Readings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
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
                if (!HourlyUsageSteamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // POST: api/HourlyUsageSteam
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HourlyUsageSteam>> Post(HourlyUsageSteam obj)
        {
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;

            obj = Calculate(obj);

            _context.UtilitiesHourlyUsageSteam.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // DELETE: api/HourlyUsageSteam/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HourlyUsageSteam>> Delete(int id)
        {
            var obj = await _context.UtilitiesHourlyUsageSteam.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            var entry = _context.Entry(obj);
            entry.State = EntityState.Deleted;

            foreach (var navigationProperty in obj.Readings.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.UtilitiesHourlyUsageSteam.Find(obj.Id)
                    .Readings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();

            return obj;
        }

        private HourlyUsageSteam Calculate(HourlyUsageSteam obj)
        {
            HourlyUsageSteam oldObj;

            if (obj.Frequency == null || obj.Frequency.Equals("Hourly"))
            {
                if (obj.Hour > 1)
                {
                    oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Contains(obj.Plant) && m.Date == obj.Date && m.Hour == (obj.Hour - 1)).FirstOrDefault();
                }
                else
                {
                    oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Contains(obj.Plant) && m.Date == (obj.Date.AddDays(-1))).OrderByDescending(m => m.Hour).FirstOrDefault();
                }
            }
            else
            {
                oldObj = _context.UtilitiesHourlyUsageSteam.Where(m => m.Plant.Contains(obj.Plant) && m.Date == (obj.Date.AddDays(-1))).FirstOrDefault();
            }


            for (int x = 0; x < obj.Readings.Count; x++)
            {
                var type = GetMeterType(obj.Plant, "SOBUTEBOI", obj.Readings.ElementAt(x).Name);
                if (type.Equals("Diminishing"))
                {
                    if (oldObj == null)
                    {
                        obj.Readings.ElementAt(x).Usage = obj.Readings.ElementAt(x).Receipt - obj.Readings.ElementAt(x).Reading;
                    }
                    else
                        obj.Readings.ElementAt(x).Usage = (oldObj.Readings.Where(m => m.Name.Equals(obj.Readings.ElementAt(x).Name)).Select(m => m.Reading).FirstOrDefault() + obj.Readings.ElementAt(x).Receipt - obj.Readings.ElementAt(x).Reading);
                }
                else
                {
                    if (oldObj == null)
                    {
                        obj.Readings.ElementAt(x).Usage = -obj.Readings.ElementAt(x).Reading;
                    }
                    else
                        obj.Readings.ElementAt(x).Usage = (obj.Readings.ElementAt(x).Reading - oldObj.Readings.Where(m => m.Name.Equals(obj.Readings.ElementAt(x).Name)).Select(m => m.Reading).FirstOrDefault());
                }
            }

            return obj;
        }

        private string GetMeterType(string Plant, string PID, string Name)
        {
            return _context.UtilitiesMeter.Where(m => m.Plant.Contains(Plant) && m.PID.Equals(PID) && m.Id == Convert.ToInt32(Name)).Select(m => m.Type).FirstOrDefault();
        }

        private bool HourlyUsageSteamExists(int id)
        {
            return _context.UtilitiesHourlyUsageSteam.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourlyUsageSteam>>> MassCalculateUsages()
        {
            var objList = await _context.UtilitiesHourlyUsageSteam.OrderBy(m => m.Date).ToListAsync();
            for (int x = 0; x < objList.Count; x++)
            {
                HourlyUsageSteam obj = Calculate(objList.ElementAt(x));
                _context.Attach(obj);

                var entry = _context.Entry(obj);
                entry.State = EntityState.Modified;
                entry.Property(e => e.Created).IsModified = false;

                foreach (var navigationProperty in obj.Readings.OrderByDescending(m => m.Id))
                {
                    bool delete = navigationProperty.Id < 0 ? true : false;
                    if (delete)
                    {
                        var entityEntry = _context.Entry(_context.UtilitiesHourlyUsageSteam.Find(obj.Id)
                            .Readings.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                        entityEntry.State = EntityState.Deleted;
                    }
                    else
                    {
                        var entityEntry = _context.Entry(navigationProperty);
                        entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                    }
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return await _context.UtilitiesHourlyUsageSteam.OrderByDescending(m => m.Date).ToListAsync();
        }


    }
}
