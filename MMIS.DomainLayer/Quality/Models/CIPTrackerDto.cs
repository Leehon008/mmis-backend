using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class CIPTrackerDto : ModelBase, IHaveCustomMappings
    {
        public DateTime Date { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal DetergentStrength { get; set; }
        public decimal DetergentTemp { get; set; }
        public decimal HotWaterTemp { get; set; }
        public string PhenopthaleinTest { get; set; }
        public string TeamLeader { get; set; }
        public string QAAnalyst { get; set; }
        public decimal PCA { get; set; }
        public decimal SDM { get; set; }
        public decimal NBB { get; set; }
        public decimal WA { get; set; }
        public decimal NBB_B { get; set; }
        public decimal WLN { get; set; }
        public string Microbiologist { get; set; }
        public string CleaningAdherance { get; set; }
        public string Effectiveness { get; set; }
        public IFormFile Deviation { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<CIPTracker, CIPTrackerDto>().ReverseMap();
        }
    }

}
