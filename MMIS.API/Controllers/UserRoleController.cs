using System;
using System.Collections.Generic;
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

    //[Authorize]
  //  [ApiExplorerSettings(GroupName = "Authentication and Authorization")]
    public class UserRoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRoleController(RoleManager<ApplicationRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        [HttpGet]
        [Route("[action]/{roleName}")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> GetRoleUsers(string roleName)
        {
            ApplicationRole role = await roleManager.FindByNameAsync(roleName);
            List<ApplicationUser> members = new List<ApplicationUser>();
            foreach (ApplicationUser user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                    members.Add(user);
            }
            return Ok(new RoleUsers
            {
                Role = role,
                Members = members
            });
        }

        [HttpGet]
        [Route("[action]/{userName}")]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            ApplicationUser user = await userManager.FindByNameAsync(userName);
            List<ApplicationRole> roles = new List<ApplicationRole>();
            foreach (ApplicationRole role in roleManager.Roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                    roles.Add(role);
            }
            return Ok(new UserRole
            {
                Roles = roles,
                User = user
            });
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> AddUserRole(string userName, string roleName)
        {
            IdentityResult result;
            ApplicationUser user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                result = await userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                    Errors(result);
                else
                    return Ok("Role added successfully");
            }

            return Ok("The operation was unsuccessful");
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> AddUserRoles(UserCreation model)
        {
            IdentityResult result;
            ApplicationUser user = await userManager.FindByNameAsync(model.userName);
            if (user != null)
            {
                foreach (string roleName in model.Roles ?? new string[] { })
                {
                    result = await userManager.AddToRoleAsync(user, roleName);
                    if (!result.Succeeded)
                        Errors(result);
                }
            }

            if (ModelState.ErrorCount > 0)
                return Ok("The operation was unsuccessful");
            else
                return Ok("Role added successfully");
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> RemoveUserRole(string userName, string roleName)
        {
            IdentityResult result;
            ApplicationUser user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                result = await userManager.RemoveFromRoleAsync(user, roleName);
                if (!result.Succeeded)
                    Errors(result);
                else
                    return Ok("Role removed successfully");
            }

            return Ok("The operation was unsuccessful");
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> RemoveUserRoles(UserCreation model)
        {
            IdentityResult result;
            ApplicationUser user = await userManager.FindByNameAsync(model.userName);
            if (user != null)
            {
                foreach (string roleName in model.Roles ?? new string[] { })
                {
                    result = await userManager.RemoveFromRoleAsync(user, roleName);
                    if (!result.Succeeded)
                        Errors(result);
                }
            }
            if (ModelState.ErrorCount > 0)
                return Ok("The operation was unsuccessful");
            else
                return Ok("Role removed successfully");
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> MassUserUpdate(UserModification model)
        {
            IdentityResult result;
            ApplicationUser user = await userManager.FindByNameAsync(model.userName);
            if (user != null)
            {
                foreach (string roleName in model.AddRoles ?? new string[] { })
                {
                    result = await userManager.AddToRoleAsync(user, roleName);
                    if (!result.Succeeded)
                        Errors(result);
                }

                foreach (string roleName in model.DeleteRoles ?? new string[] { })
                {
                    result = await userManager.RemoveFromRoleAsync(user, roleName);
                    if (!result.Succeeded)
                        Errors(result);
                }
            }

            if (ModelState.IsValid)
                return Ok("Operation Successful");
            else
                return Ok("Operation failed");
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> MassRoleUpdate(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByNameAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByNameAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return Ok("Operation Successful");
            else
                return Ok("Operation failed");
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}