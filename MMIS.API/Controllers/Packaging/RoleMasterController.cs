using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class RoleMasterController : ControllerBase
    {
        private readonly IUserRoleLogic _IRoleMasterLogic;
        private readonly IUserRoleRepository _Repository;

        public RoleMasterController(IUserRoleLogic IRoleMasterLogic, IUserRoleRepository Repository)
        {
            _IRoleMasterLogic = IRoleMasterLogic;
            _Repository = Repository;
        }

        /// <summary>
        /// Used to retrieve available RoleMasters
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await _Repository.GetData(id);
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _Repository.GetData();
            List<RoleCategory> role = new List<RoleCategory>();
            List<RoleCategory> unique = new List<RoleCategory>();
            List<string> st = new List<string>();
            foreach (var result in res.ToList())
            {
          
                st.Add(result.RoleTypeDescription);
            }
            var x = st.Distinct().ToList();
            foreach (var val in x)
            {
                RoleCategory roleCat = new RoleCategory();
                roleCat.roleCategory = val;
                role.Add(roleCat);
            }
            unique = role;

            if (unique.Count != 0)
            {
                return Ok(unique);
            }
            else if (unique.Count == 0)
            {
                return Ok("No data exists");
            }

            return BadRequest("An error occured, Please try again.");

        }

        public IEnumerable<T> DedupCollection<T>(IEnumerable<T> input)
        {
            var passedValues = new HashSet<T>();

            // Relatively simple dupe check alg used as example
            foreach (T item in input)
                if (passedValues.Add(item)) // True if item is new
                    yield return item;
        }
    
    }
}