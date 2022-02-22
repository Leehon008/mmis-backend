using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System.Collections.Generic;
using System;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class DIPlannerController : ControllerBase
    {
        private readonly IDIPlannerLogic _logic;
        
        public DIPlannerController(IDIPlannerLogic logic)
        {
            _logic = logic;
            
        }

        [HttpPost]
        public  IActionResult Create(List<DIPlannerInput> model)
        {
            var sh =  _logic.Create(model);
       
            if (sh.planner  !=null)
            {
                return Ok(sh.planner);
            }

            
            return BadRequest("Failed to create data, Please try again.");
        }

        [HttpGet]
        public  IActionResult GetData(string ShiftNo)
        {
            var data =  _logic.Get(ShiftNo);
           
            if (data != null)
            {
                return Ok(data);
            }

            return BadRequest("No data found");
        }

        [HttpGet("{id}")]
        public IActionResult UpdateWorkAssignments(string id)
        {
            try
            {
                _logic.Update(id);
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
