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


    public class PPRoboboxController : ControllerBase
    {
        private readonly IPIMsPOMsRoboboxLogic _Logic;
        
        public PPRoboboxController(IPIMsPOMsRoboboxLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMsRobobox model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.robobox != null)
            {
                return Ok(sh.robobox);
            }

            
            return BadRequest("Failed to create data, Please try again.");
        }

        
    }

}
