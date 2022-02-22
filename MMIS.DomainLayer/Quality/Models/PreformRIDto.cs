using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class PreformRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public int Sample { get; set; }
        public string Mass { get; set; }
        public string Height { get; set; }
        public string InternalDiameter { get; set; }
        public string ExternalDiameter { get; set; }
        public string Neck { get; set; }
        public string FinishGoGauge { get; set; }
        public string Visual { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<PreformRI, PreformRIDto>().ReverseMap();
        }
    }
}