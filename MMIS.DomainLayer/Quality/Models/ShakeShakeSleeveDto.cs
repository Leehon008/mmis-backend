using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class ShakeShakeSleeveDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateofDelivery { get; set; }
        public DateTime DateofManufacture { get; set; }
        public double Quantity { get; set; }
        public string Sample { get; set; }
        public string CartonAppearance { get; set; }
        public string Colour { get; set; }
        public double Quality { get; set; }
        public string Print { get; set; }
        public string CreaseAlignment { get; set; }
        public string SideSeam { get; set; }
        public string Visual { get; set; }


        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ShakeShakeSleeve, ShakeShakeSleeveDto>().ReverseMap();
        }
    }
}