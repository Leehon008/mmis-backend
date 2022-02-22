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


    public class PIMsPOMsController : ControllerBase
    {
        private readonly IPIMsPOMsLogic _pimsPomsLogic;
        
        public PIMsPOMsController(IPIMsPOMsLogic pimsPomsLogic)
        {
            _pimsPomsLogic = pimsPomsLogic;
            
        }

        [HttpPost]
        public  IActionResult CreatePIMSPOMS(List<PIMsPOMs> model)
        {
            var sh =  _pimsPomsLogic.Create(model);
       
            if (sh.pimsPoms  !=null)
            {
                return Ok(sh.pimsPoms);
            }

            
            return BadRequest("Failed to create assignment, Please try again.");
        }

        
    }

}
