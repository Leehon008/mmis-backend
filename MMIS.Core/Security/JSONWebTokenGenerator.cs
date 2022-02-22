//using MMIS.Core.Security.Contracts;
//using MMIS.DomainLayer.Entities.Users;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using MMIS.DomainLayer.Models.Users;

//namespace MMIS.Core.Security
//{
//    public class JSONWebTokenGenerator : IJSONWebTokenGenerator
//    {
//        private readonly string _secret;
//        private readonly string _expiryTime;

//        public JSONWebTokenGenerator(IConfiguration config)
//        {
//            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
//            _expiryTime = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
//        }

//        public string GenerateJSONWebToken(UserModel user)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secret);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                   // new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                    new Claim(ClaimTypes.Name, user.UserName)
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expiryTime)),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var encodedToken = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(encodedToken);
//        }
//    }
//}
