using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeLogic _IUserTypeLogic;
        private readonly IUserTypeRepository _Repository;

        public UserTypeController(IUserTypeLogic IUserTypeLogic, IUserTypeRepository Repository)
        {
            _IUserTypeLogic = IUserTypeLogic;
            _Repository = Repository;
        }

        /// <summary>
        /// Used to retrieve available UserTypes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res =await _Repository.GetData();
            if (res.Count != 0)
            {
                return Ok(res);
            }
            else if (res.Count == 0)
            {
                return Ok("No data exists");
            }

            return BadRequest("An error occured, Please try again.");
            
        }
    }
}