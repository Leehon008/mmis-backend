using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System.Collections.Generic;
using MMIS.DomainLayer.Models.Shift;
using System.Linq;
using System;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class TasksController : ControllerBase
    {
        private readonly IShiftMeetingsLogic _shiftLogic;


        public TasksController(IShiftMeetingsLogic shiftLogic)
        {
            _shiftLogic = shiftLogic;

        }

        /// <summary>
        /// Used to retrieve available shifts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetShiftMeetings(string ShiftName)
        {
            List<ShiftMeetingActions> myShift = await _shiftLogic.GetMeetingActions(ShiftName);
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


        [HttpGet("{id}")]
        public IActionResult UpdateTask( string id)
        {
            try
            {
                 _shiftLogic.UpdateTaskItem(id);
                  return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}