//using MMIS.BusinessLogicLayer.Login.Contract;
//using MMIS.Core.Security.Contracts;
//using MMIS.DomainLayer.Models.Users;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using MMIS.DataAccessLayer.Contracts;

//namespace MMIS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Microsoft.AspNetCore.Authorization.Authorize]


//    public class LoginController : ControllerBase
//    {
//        private readonly ILoginLogic _loginLogic;
//        private readonly IJSONWebTokenGenerator _jSONWebTokenGenerator;
//        private readonly IUserRepository _userRepository;

//        public LoginController(ILoginLogic loginLogic, IJSONWebTokenGenerator jSONWebTokenGenerator, IUserRepository userRepository)
//        {
//            _loginLogic = loginLogic;
//            _jSONWebTokenGenerator = jSONWebTokenGenerator;
//            _userRepository = userRepository;
//        }

//        /// <summary>
//        /// Used to generate JWT Token
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public async Task<IActionResult> Login(UserModel model)
//        {
//           // var profile = await _loginLogic.Login(model);
//            var loginResponse = await _loginLogic.SignIn(model);
//           // var loginUser = await _userRepository.GetUserByUserNameAsync(model.UserName);
//            var userProfile =  _loginLogic.GetProfile(model.UserName);
//            if (userProfile == null)
//            {
//                return BadRequest("User has not been created.");
//            }
//            if (!loginResponse.result)
//            {
//                return BadRequest("Username or Password Incorrect");
//            }
//            if (loginResponse.result && userProfile.UserName !=null)
//            {

//                var token = _jSONWebTokenGenerator.GenerateJSONWebToken(model);
//                userProfile.token = token;
//                return Ok( userProfile);
//            }

            
//            return BadRequest("An error accured, Please try again.");
//        }
//    }
//}