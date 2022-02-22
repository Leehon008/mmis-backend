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


    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionsLogic _inspectLogic;
        
        public InspectionsController(IInspectionsLogic inspectLogic)
        {
            _inspectLogic = inspectLogic;
            
        }

        [HttpPost]
        public  IActionResult CreateInspections(List<Inspections> model)
        {
            var sh =  _inspectLogic.CreateInspections(model);
       
            if (sh.inspections  !=null)
            {
                return Ok(sh.inspections);
            }

            
            return BadRequest("Failed to create assignment, Please try again.");
        }

        [HttpGet]
        public  IActionResult getInspections(string ShiftNo)
        {
            var sh =  _inspectLogic.GetInspections(ShiftNo);
           
            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("No data found");
        }

        [HttpGet("{ShiftNo}/{user}")]
        public IActionResult getInspectionsByArtisan(string ShiftNo,string user)
        {
            var sh = _inspectLogic.GetInspections(ShiftNo,user);

            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("No data found");
        }



        [HttpGet("{id}")]
        public IActionResult UpdateWorkAssignments(string id)
        {
            try
            {
                _inspectLogic.UpdateWorkAssignments(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }

}
