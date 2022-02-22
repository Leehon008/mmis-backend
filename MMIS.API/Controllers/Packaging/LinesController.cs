using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System.Collections.Generic;
using MMIS.DomainLayer.Models.Shift;
using System.Linq;
using MMIS.DataAccessLayer.Users;
using MMIS.DomainLayer.Models.Users;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class LineController : ControllerBase
    {
        private readonly ILineLogic _ILineLogic;
      
        private readonly ILineRepository _lineRepository;

        public LineController(ILineLogic ILineLogic, ILineRepository lineRepository)
        {
            _ILineLogic = ILineLogic;
         
            _lineRepository = lineRepository;
        }

        /// <summary>
        /// Used to retrieve available Lines
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetLine(string plantId)
        {
            var myShift = await _ILineLogic.GetLineById(plantId);
            if (myShift.Count != 0)
            {
                return Ok(myShift);
            }
            else if (myShift.Count == 0)
            {
                return Ok("No data exists");
            }

            return BadRequest("An error occured, Please try again.");

        }
    }
}