using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class YeastRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public string BestBeforeDate { get; set; }
        public string Quantity { get; set; }
        public string AlcoholProduction { get; set; }
        public string FoamFormation { get; set; }
        public string Colour { get; set; }
        public string MoistureContent { get; set; }
        public string ShelfLife { get; set; }
        public string TotalBacteria { get; set; }
        public string Lactobacillus { get; set; }
        public string WildYeast { get; set; }
        public string EColi { get; set; }
        public string Coliforms { get; set; }
        public string LiveCellCount { get; set; }
        public string Viability { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<YeastRI, YeastRIDto>().ReverseMap();
        }
    }
}
