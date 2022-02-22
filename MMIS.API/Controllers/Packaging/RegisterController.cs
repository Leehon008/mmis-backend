//using MMIS.BusinessLogicLayer.Register.Contract;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using MMIS.DataAccessLayer.Contracts;
//using MMIS.DomainLayer.Entities.Users;

//namespace MMIS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Microsoft.AspNetCore.Authorization.Authorize]


//    public class RegisterController : ControllerBase
//    {
//        private readonly IRegisterLogic _registerLogic;
//        private readonly IUserRepository _userRepository;

//        public RegisterController(IRegisterLogic registerLogic, IUserRepository userRepository)
//        {
//            _registerLogic = registerLogic;
//            _userRepository = userRepository;
//        }

//        / <summary>
//        / Used to generate JWT Token
//        / </summary>
//        / <param name = "model" ></ param >
//        / < returns ></ returns >
//        [HttpPost]
//        public async Task<IActionResult> Register(User model)
//        {
//            var register = await _registerLogic.Register(model);


//            if (register.User != null)
//            {
//                return Ok(new { register });
//            }


//            return BadRequest("An error occured, Please try again.");
//        }
//    }
//}