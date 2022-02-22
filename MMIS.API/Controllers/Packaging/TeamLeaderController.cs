using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.BusinessLogicLayer.Shift.Contract;
using System.Collections.Generic;
using MMIS.DomainLayer.Models.Shift;
using System.Linq;
using MMIS.DataAccessLayer.Users;
using MMIS.DomainLayer.Models.Users;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class TeamLeadersController : ControllerBase
    {
        private readonly ITeamLeaderLogic _iteamLeaderLogic;
       // private readonly IUserRepository _userRepository;
        private readonly ITeamLeadersRepository _teamleaderRepository;

        public TeamLeadersController(ITeamLeaderLogic iteamLeaderLogic, ITeamLeadersRepository teamleaderRepository)
        {
            _iteamLeaderLogic = iteamLeaderLogic;
           // _userRepository = userRepository;
            _teamleaderRepository = teamleaderRepository;
        }

        /// <summary>
        /// Used to retrieve available shifts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> GetTeamLeaders(string plantId)
        {
            PersonnelResultDto myShift =await  _iteamLeaderLogic.GetTeamLeaderById(plantId);
            if (myShift.teamLeaders.Count != 0)
            {
                return Ok(myShift.teamLeaders);
            }
            else if (myShift.teamLeaders.Count == 0)
            {
                return Ok("No data exists");
            }

            return BadRequest("An error occured, Please try again.");
            
        }
    }
}