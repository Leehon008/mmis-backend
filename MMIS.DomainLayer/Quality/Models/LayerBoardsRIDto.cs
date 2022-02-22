using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class LayerBoardsRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateofDelivery { get; set; }

        public DateTime DateofManufacture { get; set; }
        public double Quantity { get; set; }

        public double Sample { get; set; }
        public double Width { get; set; }
        public double RepeatLength { get; set; }
        public string Colour { get; set; }
        public string Shape { get; set; }
        public string Visual { get; set; }


        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<LayerBoardsRI, LayerBoardsRIDto>().ReverseMap();
        }
    }
}