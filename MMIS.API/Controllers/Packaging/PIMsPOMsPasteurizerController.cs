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


    public class PPPasteurizerController : ControllerBase
    {
        private readonly IPIMsPOMsPasteurizerLogic _Logic;
        
        public PPPasteurizerController(IPIMsPOMsPasteurizerLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMsPasteurizer model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.pastuerizer !=null)
            {
                return Ok(sh.pastuerizer);
            }

            
            return BadRequest("Failed to create data, Please try again.");
        }

        
    }

}
