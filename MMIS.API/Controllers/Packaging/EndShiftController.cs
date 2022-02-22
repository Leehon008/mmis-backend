using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class EndShiftController : ControllerBase
    {
        private readonly IEndShiftLogic _Logic;
        
        public EndShiftController(IEndShiftLogic Logic)
        {
            _Logic = Logic;
            
        }
      
      

        [HttpPost]
        public IActionResult Update(EndShift model)
        {
            try
            {
                if (model.StatusId == 2.ToString())
                {
                    _Logic.Create(model);
                }
               
                _Logic.Update(model.ShiftNo,model.StatusId);
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
