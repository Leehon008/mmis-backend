using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class LacticAcidRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public string ExpiryDate { get; set; }
        public string Strength { get; set; }
        public string Color { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<LacticAcidRI, LacticAcidRIDto>().ReverseMap();
        }
    }
}