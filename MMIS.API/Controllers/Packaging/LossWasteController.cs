using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Authorization.Authorize]


    public class LossWasteController : ControllerBase
    {
        private readonly ILWHeaderLogic _lwLogic;
        
        public LossWasteController(ILWHeaderLogic lwLogic)
        {
            _lwLogic = lwLogic;
            
        }
        /// <summary>
        /// Used to generate JWT Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWL(LossWasteHeader model)
        {
            var sh = await _lwLogic.CreateWL(model);
            if (sh.lw  !=null)
            {
                return Ok(sh.lw);
            }

            
            return BadRequest("Failed to post, Please try again.");
        }

        [HttpGet]
        public async Task<IActionResult> GetData(string Plant)
        {
            var sh = await _lwLogic.GetData(Plant);
           
            if (sh != null)
            {
                return Ok(sh);
            }

            return BadRequest("No data exist, Please try again.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedBack(string id)
        {
            var sh =  _lwLogic.GetFeedBack(id);


            if (sh != null)
            {
                //sh.CumulativeFactoryHours = Math.Round(sh.CumulativeFactoryHours, 2);
                sh.CumulativeTPV = Math.Round(sh.CumulativeTPV, 2);
                sh.FactoryEfficiency = Math.Round(sh.FactoryEfficiency, 2);
                sh.MachineEfficiency = Math.Round(sh.MachineEfficiency, 2);
                sh.HourlyTPV = Math.Round(sh.HourlyTPV, 2);
                return Ok(sh);
            }

            return BadRequest("No data exist, Please try again.");
        }
    }

}
