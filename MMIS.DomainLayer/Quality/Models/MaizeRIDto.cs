using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class MaizeRIDto : IHaveCustomMappings
    {
        public string Plant { get; set; }
        public string Analyst { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Supplier { get; set; }
        public string TruckNum { get; set; }
        public string SiloOffloadedInto { get; set; }
        public decimal Quantity { get; set; }
        public decimal Moisture { get; set; }
        public decimal Chipped { get; set; }
        public decimal Defective { get; set; }
        public decimal TotalDensity { get; set; }
        public decimal Trash { get; set; }
        public decimal ExtraMatter { get; set; }
        public decimal WeevilsInfestationLive { get; set; }
        public decimal WeevilsInfestationDead { get; set; }
        public decimal Extract { get; set; }
        public string Colour { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<MaizeRI, MaizeRIDto>().ReverseMap();
        }
    }
}
