using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class ClosureRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public int Sample { get; set; }
        public decimal Mass { get; set; }
        public decimal Height { get; set; }
        public decimal Diameter { get; set; }
        public string TemperEvidenceBand { get; set; }
        public string Printing { get; set; }
        public string Color { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ClosureRI, ClosureRIDto>().ReverseMap();
        }
    }
}