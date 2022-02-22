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


    public class PPFillerController : ControllerBase
    {
        private readonly IPIMsPOMsFillerLogic _Logic;
        
        public PPFillerController(IPIMsPOMsFillerLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMsFiller model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.filler !=null)
            {
                return Ok(sh.filler);
            }

            
            return BadRequest("Failed to create data, Please try again.");
        }

        
    }

}
