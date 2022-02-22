using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class CarbonDioxideRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public string Tank { get; set; }
        public string Quantity { get; set; }
        public string Taste { get; set; }
        public string Odour { get; set; }
        public string ApperanceInWater { get; set; }
        public string Purity { get; set; }
        public string OdourAfterAcidification { get; set; }
        public string SnowTest { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<CarbonDioxideRI, CarbonDioxideRIDto>().ReverseMap();
        }
    }
}
