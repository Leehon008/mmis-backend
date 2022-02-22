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
    public class HRAHeaderDto : IHaveCustomMappings
    {
        [Required]
        public string ProductName { get;  set; }
        [Required]
        public string ProductCode { get;  set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Center { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public DateTime DateOfSDS { get; set; }
        [Required]
        public string SDSHeld { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string ProcessDescription { get; set; }
        [Required]
        public double QuantitiesUsed { get; set; }
        [Required]
        public double MaxTemperature { get; set; }
        [Required]
        public string Unit { get; set; }

        [Required]
        public int ExposurePeriod { get; set; }

        [Required]
        public string OveralUasgeAssement { get; set; }

        [Required]
        public bool CurrentControlEffective { get; set; }
        [Required]
        public bool SDsControlsNotInPlace { get; set; }
        [Required]
        public bool AirMonitoringConsidered { get; set; }
        [Required]
        public bool ProcessReengineered { get; set; }
        [Required]
        public bool LessDangerousSubConsidered { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }
        public virtual ICollection<HRAExposureRoute> HRAExposureRoute { get; set; }
        
        public virtual ICollection<HRAAffectedPersons> HRAAffectedPersons { get; set; }
       
        public virtual ICollection<HRAAssociatedRisk> HRAAssociatedRisk { get; set; }
        public virtual ICollection<HRAClassification> HRAClassification { get; set; }
        public virtual ICollection<HRAControls> HRAControls { get; set; }
        public virtual ICollection<HRAEmergencyAction> HRAEmergencyAction { get; set; }
    
        public virtual ICollection<HRAHandlingControls> HRAHandlingControls { get; set; }

        public virtual ICollection<HRAImprovementSuggestion> HRAImprovementSuggestion { get; set; }
        public virtual ICollection<HRARequirements> HRARequirements { get; set; }
        public virtual ICollection<HRASubstancesProduced> HRASubstancesProduced { get; set; }
   


        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<HRAHeader, HRAHeaderDto>().ReverseMap();
        }

    }
}

