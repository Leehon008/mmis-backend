using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMIS.DomainLayer.Authentication;
using Swashbuckle.AspNetCore.Annotations;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Authorization.Authorize]

    //[Authorize(Roles = UserRoles.Admin)]
    //[ApiExplorerSettings(GroupName = "Authentication and Authorization")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<ApplicationRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetList() => Ok(roleManager.Roles);

        //public IActionResult Create() => View();

        [HttpPost]
        [Route("[action]")]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> Create([Required] string name, string userGroup, string roleType)
        {
            var currentuser = User.Identity.Name;
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager
                    .CreateAsync(new ApplicationRole
                    {
                        Created = DateTime.Now,
                        Name = name,
                        Usergroup = userGroup,
                        RoleType = roleType,
                        CreatedBy = currentuser
                    });
                if (result.Succeeded)
                    return Ok("Role created successfully");
                else
                    Errors(result);
            }
            return Ok("The operation was unsuccessfully");
        }

        [HttpPost]
        [Route("[action]")]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> Delete(string name)
        {
            ApplicationRole role = await roleManager.FindByNameAsync(name);
            if (role != null && !role.Name.Equals(UserRoles.Admin))
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return Ok("Delete successful");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return Ok(roleManager.Roles);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }

}