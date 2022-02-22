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


    public class PPBlowMoulderController : ControllerBase
    {
        private readonly IPIMsPOMsBlowMoulderLogic _Logic;
        
        public PPBlowMoulderController(IPIMsPOMsBlowMoulderLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMsBlowMoulder model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.blowmoulder !=null)
            {
                return Ok(sh.blowmoulder);
            }

            
            return BadRequest("Failed to create data, Please try again.");
        }

        
    }

}
