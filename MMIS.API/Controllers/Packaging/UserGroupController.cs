using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupLogic _IUserGroupLogic;
        private readonly IUserGroupRepository _Repository;

        public UserGroupController(IUserGroupLogic IUserGroupLogic, IUserGroupRepository Repository)
        {
            _IUserGroupLogic = IUserGroupLogic;
            _Repository = Repository;
        }

        /// <summary>
        /// Used to retrieve available UserGroups
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