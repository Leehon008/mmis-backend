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


    public class CMArtisanController : ControllerBase
    {
        private readonly ICMArtisanLogic _logic;
        
        public CMArtisanController(ICMArtisanLogic logic)
        {
            _logic = logic;
            
        }

        [HttpPost]
        public  IActionResult Create(List<CMArtisanInput> model)
        {
            var data =  _logic.Create(model);
       
            if (data.CMArtisan  !=null)
            {
                return Ok(data.CMArtisan);
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
        public IActionResult Update(string id)
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
