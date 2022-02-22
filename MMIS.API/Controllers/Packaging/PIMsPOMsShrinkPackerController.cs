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


    public class PPShrinkPackerController : ControllerBase
    {
        private readonly IPIMsPOMsShrinkPackerLogic _Logic;
        
        public PPShrinkPackerController(IPIMsPOMsShrinkPackerLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMShrinkPacker model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.spacker !=null)
            {
                return Ok(sh.spacker);
            }

            
            return BadRequest("Failed to create assignment, Please try again.");
        }

        
    }

}
