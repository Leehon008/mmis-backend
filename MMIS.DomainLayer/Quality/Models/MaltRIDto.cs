using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Models
{
    public class MaltRIDto : ModelBaseCOA, IHaveCustomMappings
    {
        public string DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public decimal Moisture { get; set; }
        public decimal SDU { get; set; }
        public decimal Solubility { get; set; }
        public decimal MaltActivity { get; set; }
        public decimal Extract { get; set; }
        public decimal TBC { get; set; }
        public string SandDetection { get; set; }
        public decimal FreeAminoNitrogen { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<MaltRI, MaltRIDto>().ReverseMap();
        }
    }
}
