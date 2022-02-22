using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class AttenuzymeRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public string DateofDelivery { get; set; }
 
        public string DateofManufacture { get; set; }
        public string Quantity { get; set; }
        public string Sample { get; set; }
        public string Density { get; set; }
        public string ColiformBacteria { get; set; }
        public string Ecoli { get; set; }
        public string Yeast { get; set; }
        public string BeerSpoilageBacteria { get; set; }
        public string Mold { get; set; }
        public string Visual { get; set; }
    

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<AttenuzymeRI, AttenuzymeRIDto>().ReverseMap();
        }
    }
}