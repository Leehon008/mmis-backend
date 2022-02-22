using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class GlueRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public string GlueCode { get; set; }
        public string BucketCondition { get; set; }
        public string Color { get; set; }
        public string BucketSize { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<GlueRI, GlueRIDto>().ReverseMap();
        }
    }
}