using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class LabelRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Layout { get; set; }
        public string Spikes { get; set; }
        public string Overlap { get; set; }
        public string BarCode { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Direction { get; set; }
        public string Separation { get; set; }
        public string Packing { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<LabelRI, LabelRIDto>().ReverseMap();
        }
    }


    public class MealieMealRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public DateTime DateofDelivery { get; set; }
    
        public double Quantity { get; set; }
        public string Moisture { get; set; }
        public double Mesh12 { get; set; }
        public double Mesh16 { get; set; }
        public double Mesh30 { get; set; }
        public string Appearance { get; set; }
        public string AnalystInitials { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<MealieMealRI, MealieMealRIDto>().ReverseMap();
        }
    }
}