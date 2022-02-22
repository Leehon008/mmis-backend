using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class BeginShiftController : ControllerBase
    {
        private readonly IBeginShiftLogic _shiftHeaderLogic;
        
        public BeginShiftController(IBeginShiftLogic shiftHeaderLogic)
        {
            _shiftHeaderLogic = shiftHeaderLogic;
            
        }
        /// <summary>
        /// Used to generate JWT Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BeginShiftPost(ShiftHeader model)
        {
            var sh = await _shiftHeaderLogic.BeginShift(model);
            TaskNo task = new TaskNo();
            task.taskNo = sh.shiftHeader.ShiftNo;


            if (sh.shiftHeader  !=null)
            {
                return Ok(task);
            }
            
            return BadRequest("The shift have not been created, Please try again.");
        }

        [HttpGet("{plant}/{moduleId}")]
        public  async Task<IActionResult> Get(string plant, string moduleId)
        {
            var sh = await _shiftHeaderLogic.GetShifts(plant,moduleId);

            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("The shift have not been created, Please try again.");
        }


        [HttpGet]
        public async Task<IActionResult> gtActiveShift(string Plant)
        {
            var sh = await _shiftHeaderLogic.GetActiveShifts(Plant);

            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("Could not get shifts, Please try again.");
        }

        // [Route("/[action]")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShift(string id)
        {
            var sh = await _shiftHeaderLogic.GetShift(id);

            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("Could not get shift, Please try again.");
        }
    }

}
