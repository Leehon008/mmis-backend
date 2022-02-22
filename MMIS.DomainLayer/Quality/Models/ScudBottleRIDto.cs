using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class ScudBottleRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public decimal CavityNumber { get; set; }
        public decimal Mass { get; set; }
        public decimal TotalBottleHeight { get; set; }
        public decimal NODPThread { get; set; }
        public decimal NODNThread { get; set; }
        public decimal NODRatchettoratchet { get; set; }
        public decimal Neckheightratchet { get; set; }
        public decimal Neck { get; set; }
        public decimal RatchetHeight { get; set; }
        public decimal NeckInsidediameter { get; set; }
        public decimal Bottleridgediameter { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<ScudBottleRI, ScudBottleRIDto>().ReverseMap();
        }
    }
}