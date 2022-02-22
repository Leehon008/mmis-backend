using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.Entities.Users;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MMIS.API.Controllers
{
    [Route("api")]
    [ApiController]

    //[ApiExplorerSettings(GroupName = "Authentication and Authorization")]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly MMISDbContext _context;


        public AuthenticateController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, MMISDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    user = _mapper.Map<ApplicationUser, RegisterModel>(user),
                    roles = userRoles,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            var currentuser = User.Identity.Name;
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Designation = model.Designation,
                Country = model.Country,
                PlantId = model.PlantId,
                Created = DateTime.Now,
                CreatedBy = currentuser,
                Usergroup = model.Usergroup,
                UserType = model.Usertype,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            var roleresult = await userManager.AddToRoleAsync(user, UserRoles.Standard);
            if (!roleresult.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Standard User role assignment failed!" });
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("updateuser")]
        [Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> UpdateUser([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User does not exist!" });

            userExists.Email = model.Email;
            userExists.FirstName = model.FirstName;
            userExists.LastName = model.LastName;
            userExists.PhoneNumber = model.PhoneNumber;
            userExists.Designation = model.Designation;
            userExists.Country = model.Country;
            userExists.PlantId = model.PlantId;
            userExists.Usergroup = model.Usergroup;
            userExists.UserType = model.Usertype;

            var result = await userManager.UpdateAsync(userExists);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User update failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User update successfully!" });
        }

        [HttpPost]
        [Route("de-register")]
        [Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public async Task<IActionResult> Deregister(string username)
        {
            var userExists = await userManager.FindByNameAsync(username);
            if (userExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User does not exists!" });

            var result = await userManager.DeleteAsync(userExists);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User deletion failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User deleted successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Classified" })]
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            if (!model.RegKey.Equals(UserRoles.RegKey))
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unauthorized Operation! please contact system administrator." });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Designation = model.Designation,
                Usergroup = "IT",
                UserType = "Administrator",
                Created = DateTime.Now,
                CreatedBy = model.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Admin });

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("getusers")]
        //[Authorize(Roles = UserRoles.Admin)]
        //[SwaggerOperation(Tags = new[] { "Authentication and Authorization - Admin Operations" })]
        public ActionResult GetUsers()
        {
            List<RegisterModel> users = new List<RegisterModel>();
            foreach (ApplicationUser user in userManager.Users)
            {
                users.Add(_mapper.Map<ApplicationUser, RegisterModel>(user));
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("massregister")]
        public async Task<IActionResult> MassRegister()
        {
            List<UserOld> ulist = await _context.UserOld.ToListAsync();

            foreach (UserOld model in ulist)
            {
                var userExists = await userManager.FindByNameAsync(model.UserName);
                if (userExists == null)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.Cell,
                        Designation = model.Designation,
                        Country = "Zimbabwe",
                        PlantId = model.PlantId,
                        Created = DateTime.Now,
                        CreatedBy = "amuramba",
                        Usergroup = model.UsergroupID,
                        UserType = model.UserTypeID,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.UserName
                    };

                    userManager.CreateAsync(user).Wait();
                }
            }
            return Ok(new Response { Status = "Success", Message = "Users created successfully!" });
        }


    }
}
