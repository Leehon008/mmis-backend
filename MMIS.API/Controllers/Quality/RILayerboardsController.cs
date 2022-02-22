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


    public class RILayerboardsController : ControllerBase
    {
        private readonly MMISDbContext _context;

        private readonly IFileUploadLogic _fileUploadLogic;
        private readonly IMapper _mapper;

        public RILayerboardsController(MMISDbContext context, IFileUploadLogic fileUploadLogic, IMapper mapper)
        {
            _context = context;
            _fileUploadLogic = fileUploadLogic;
            _mapper = mapper;
        }

 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LayerBoardsRI>>> GetLayerBoardsRI(string Plant)
        {
            return await _context.QualityRILayerBoardsRI.Where(m => m.Plant.Contains(Plant)).OrderByDescending(m => m.DateOfDelivery).ToListAsync();
        }

        // GET: api/LayerBoardsRIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LayerBoardsRI>> GetLayerBoardsRI(int id)
        {
            var labelRI = await _context.QualityRILayerBoardsRI.FindAsync(id);

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }
        [HttpGet("{batch}")]
        public async Task<ActionResult<LayerBoardsRI>> Get(string batch)
        {
            var labelRI = await _context.QualityRILayerBoardsRI.Where(m => m.BatchNo == batch).FirstOrDefaultAsync();

            if (labelRI == null)
            {
                return NotFound();
            }

            return labelRI;
        }

        // PUT: api/LayerBoardsRIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayerBoardsRI(int id, LayerBoardsRIDto obj)
        {
            LayerBoardsRI labelRI = _mapper.Map<LayerBoardsRI>(obj);
            labelRI.Id = id;
            labelRI.Created = _context.QualityRILayerBoardsRI.Where(m => m.Id == id).Select(m => m.Created).FirstOrDefault();
            labelRI.COA = _context.QualityRILayerBoardsRI.Where(m => m.Id == id).Select(m => m.COA).FirstOrDefault();
            labelRI.Modified = DateTime.Now;
            //labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\Labels").Result;
            _context.Entry(labelRI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayerBoardsRIExists(id))
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

        // POST: api/LayerBoardsRIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LayerBoardsRI>> PostLayerBoardsRI([FromForm] LayerBoardsRIDto obj)
        {
            LayerBoardsRI labelRI = _mapper.Map<LayerBoardsRI>(obj);
            labelRI.Created = DateTime.Now;
            labelRI.Modified = labelRI.Created;
            labelRI.COA = _fileUploadLogic.UploadFile(obj.COA,"Quality", "Inspections\\Packaging\\LayerBoards").Result;
            _context.QualityRILayerBoardsRI.Add(labelRI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayerBoardsRI", new { id = labelRI.Id }, labelRI);
        }

        // DELETE: api/LayerBoardsRIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LayerBoardsRI>> DeleteLayerBoardsRI(int id)
        {
            var labelRI = await _context.QualityRILayerBoardsRI.FindAsync(id);
            if (labelRI == null)
            {
                return NotFound();
            }

            _context.QualityRILayerBoardsRI.Remove(labelRI);
            await _context.SaveChangesAsync();

            return labelRI;
        }

        private bool LayerBoardsRIExists(int id)
        {
            return _context.QualityRILayerBoardsRI.Any(e => e.Id == id);
        }
    }
}
