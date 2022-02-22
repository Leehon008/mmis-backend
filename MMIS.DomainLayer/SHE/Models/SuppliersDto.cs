using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SuppliersDto : IHaveCustomMappings
    {
        [Required]
        public string SupplierName { get;  set; }
        [Required]
        public string Description { get;  set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public int EvaluationScore { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string Decision { get; set; }
        public string CreatedBy { get; set; }
        public string Plant { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }
        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<Suppliers, SuppliersDto>().ReverseMap();
        }


    }
}

    

