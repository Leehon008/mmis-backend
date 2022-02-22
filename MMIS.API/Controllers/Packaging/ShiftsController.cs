using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System.Collections.Generic;
using MMIS.DomainLayer.Models.Shift;
using System.Linq;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class ShiftsController : ControllerBase
    {
        private readonly IShiftLogic _shiftLogic;
   
        private readonly IShiftRepository _shiftRepository;

        public ShiftsController(IShiftLogic shiftLogic, IShiftRepository shiftRepository)
        {
            _shiftLogic = shiftLogic;
       
            _shiftRepository = shiftRepository;
        }

        /// <summary>
        /// Used to retrieve available shifts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> Shift(string plantId,string moduleId)
        {
            List<Shifts> myShift =  _shiftLogic.Shifts(plantId, moduleId);
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