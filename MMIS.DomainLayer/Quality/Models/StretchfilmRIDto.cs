using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class StretchfilmRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public string Width { get; set; }
        public string Gauge { get; set; }
        public string CodeDiameter { get; set; }
        public string CodeShape { get; set; }
        public string ReelCondition { get; set; }
        public string Mass { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<StretchfilmRI, StretchfilmRIDto>().ReverseMap();
        }
    }
}