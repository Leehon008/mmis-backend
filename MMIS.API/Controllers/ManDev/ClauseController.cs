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
using MMIS.DomainLayer.ManDev.Dto;
using MMIS.DomainLayer.ManDev.Entities;

namespace MMIS.API.Controllers.ManDev
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class ClauseController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public ClauseController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

        // GET: api/Clauses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Clause>>> GetClauses()
        //{
        //    return await _context.MandevClause.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clause>>> GetClauses(string Plant)
        {
            return await _context.MandevClause.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.Date).ToListAsync();
        }

        // GET: api/Clauses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clause>> GetClause(int id)
        {
            var obj = await _context.MandevClause.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // PUT: api/Clauses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClause(int id,ClauseDto objDto)
        {
            Clause obj = _mapper.Map<Clause>(objDto);
            obj.Id = id;
            obj.Created = _context.MandevClause.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            obj.Modified = DateTime.Now;
            _context.Entry(obj).State = EntityState.Modified;

            foreach (var navigationProperty in obj.Sections.OrderByDescending(m => m.Id))
            {
                bool delete = navigationProperty.Id < 0 ? true : false;
                if (delete)
                {
                    var entityEntry = _context.Entry(_context.MandevClause.Find(obj.Id)
                        .Sections.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                    entityEntry.State = EntityState.Deleted;
                    foreach (var nestedNavigationProperty in navigationProperty.Evidence.OrderByDescending(m => m.Id))
                    {
                        var nestedEntityEntry = _context.Entry(_context.MandevClause.Find(obj.Id)
                            .Sections.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                            .Evidence.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                        nestedEntityEntry.State = EntityState.Deleted;
                    }
                }
                else
                {
                    var entityEntry = _context.Entry(navigationProperty);
                    entityEntry.State = navigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                    foreach (var nestedNavigationProperty in navigationProperty.Evidence.OrderByDescending(m => m.Id))
                    {
                        bool nestedDelete = (nestedNavigationProperty.Id < 0) ? true : false;
                        if (nestedDelete)
                        {
                            var nestedEntityEntry = _context.Entry(_context.MandevClause.Find(obj.Id)
                                .Sections.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                                .Evidence.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                            nestedEntityEntry.State = EntityState.Deleted;
                        }
                        else
                        {
                            var nestedEntityEntry = _context.Entry(nestedNavigationProperty);
                            nestedEntityEntry.State = nestedNavigationProperty.Id == 0 ? EntityState.Added : EntityState.Modified;
                        }
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClauseExists(id))
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

        // POST: api/Clauses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clause>> PostClause(ClauseDto objDto)
        {
            Clause obj = _mapper.Map<Clause>(objDto);
            obj.Created = DateTime.Now;
            obj.Modified = obj.Created;

            foreach (var navigationProperty in objDto.Sections)
            {
                Section section = _mapper.Map<Section>(navigationProperty);
                foreach (var nestedNavigationProperty in navigationProperty.Evidence)
                {
                    Evidence evidence = _mapper.Map<Evidence>(nestedNavigationProperty);
                    section.Evidence.Add(evidence);
                }
                obj.Sections.Add(section);
            }

            _context.MandevClause.Add(obj);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClause", new { id = obj.Id }, obj);
        }

        [HttpPost("upload-evidence")]
        public ActionResult<EvidencePath> UploadEvidence([FromForm] EvidenceFile file)
        {
            EvidencePath path = new EvidencePath
            {
                File = _fileUploadLogic.UploadFile(file.File, "Mandev", "Clauses\\Evidence").Result
            };
            return path;
        }

        // DELETE: api/Clauses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clause>> DeleteClause(int id)
        {
            var obj = await _context.MandevClause.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Entry(obj).State = EntityState.Deleted;

            foreach (var navigationProperty in obj.Sections.OrderByDescending(m => m.Id))
            {
                var entityEntry = _context.Entry(_context.MandevClause.Find(obj.Id)
                    .Sections.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault());
                entityEntry.State = EntityState.Deleted;
                foreach (var nestedNavigationProperty in navigationProperty.Evidence.OrderByDescending(m => m.Id))
                {
                    var nestedEntityEntry = _context.Entry(_context.MandevClause.Find(obj.Id)
                        .Sections.Where(m => m.Id == Math.Abs(navigationProperty.Id)).FirstOrDefault()
                        .Evidence.Where(m => m.Id == Math.Abs(nestedNavigationProperty.Id)).FirstOrDefault());
                    nestedEntityEntry.State = EntityState.Deleted;
                }
            }
            //_context.MandevClause.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool ClauseExists(int id)
        {
            return _context.MandevClause.Any(e => e.Id == id);
        }
    }
}
