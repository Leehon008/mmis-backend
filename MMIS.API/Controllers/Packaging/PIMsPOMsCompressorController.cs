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


    public class PPCompressorController : ControllerBase
    {
        private readonly IPIMsPOMsCompressorLogic _Logic;
        
        public PPCompressorController(IPIMsPOMsCompressorLogic Logic)
        {
            _Logic = Logic;
            
        }

        [HttpPost]
        public  IActionResult Create(PIMsPOMsCompressor model)
        {
            var sh =  _Logic.Create(model);
       
            if (sh.compressor !=null)
            {
                return Ok(sh.compressor);
            }

            
            return BadRequest("Failed to create assignment, Please try again.");
        }

        
    }

}
