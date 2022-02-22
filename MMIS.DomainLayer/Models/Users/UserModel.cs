//using AutoMapper.Configuration;
//using MMIS.CommonLayer.Automapper.Contracts;
//using MMIS.DomainLayer.Entities.Users;
//using System.ComponentModel.DataAnnotations;

//namespace MMIS.DomainLayer.Models.Users
//{
//    public class UserModel : IHaveCustomMappings
//    {
//        [Required]
//        public string UserName { get; set; }
//        [Required]
//        public string Password { get; set; }

//        public void CreateMaps(MapperConfigurationExpression config)
//        {
//            config.CreateMap<User, UserModel>().ReverseMap();
//        }
//    }
//}
