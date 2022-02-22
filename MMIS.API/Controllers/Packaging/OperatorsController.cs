using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DomainLayer.Models.Users;
using MMIS.BusinessLogicLayer.Operators.Contract;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using AutoMapper;
using MMIS.DataAccessLayer.Shared;
using System.Linq;
using System;
using Operators = MMIS.DomainLayer.Entities.Users.Operators;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class OperatorsController : ControllerBase
    {
        private readonly IOperatorLogic _operatorLogic;
        //  private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IMapper _mapper;
        private readonly MMISDbContext _context;


        public OperatorsController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<ApplicationRole> roleManager,MMISDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Used to retrieve available shifts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> GetOperators(string Id,string moduleId)
        {

            List<Operators> users = new List<Operators>();
            foreach (ApplicationUser user in userManager.Users)
            {
                if (user.Designation.ToLower().Equals("TeamLeader".ToLower()))
                {
                    user.Designation = "Operator";
                }
                if ( user.Designation.ToLower().Equals("Operator".ToLower()) && user.PlantId.ToLower().Equals(Id.ToLower()) && user.Usergroup.ToLower().Equals(moduleId.ToLower()))
                {

                    Operators op = new DomainLayer.Entities.Users.Operators
                    {
                        OperatorGroupId = user.Usergroup,
                        OperatorId = user.UserName,
                        OperatorName = user.UserName,
                        Active = true,
                        DateCreated = user.Created,
                        DateModified = user.Created,
                        Id = 0,// int.Parse(user.Id),
                        PlantId = user.PlantId

                    };
                    users.Add(op);
                }
            }
            return Ok(users);

            
            
        }
    }
}