using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using MMIS.CommonLayer.Automapper.Contracts;
using System;

namespace MMIS.DomainLayer.Authentication
{
    public class ApplicationUser: IdentityUser, IHaveCustomMappings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string Country { get; set; }
        public string PlantId { get; set; }
        public string Designation { get; set; }
        public string Usergroup { get; set; }
        public string UserType { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ApplicationUser, RegisterModel>().ReverseMap();
        }
    }
}
