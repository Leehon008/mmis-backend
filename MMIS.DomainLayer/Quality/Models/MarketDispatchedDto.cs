using AutoMapper.Configuration;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class MarketDispatchedDto : ModelBase, IHaveCustomMappings
    {
        public DateTime Date { get; set; }
        public string Driver { get; set; }
        public string Route { get; set; }
        public string BatchNumber{ get; set; }
        public DateTime BBDate { get; set; }
        public int Quantity { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<MarketDispatched, MarketDispatchedDto>().ReverseMap();
        }
    }
}
