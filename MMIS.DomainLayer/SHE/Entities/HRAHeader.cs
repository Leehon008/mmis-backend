using Microsoft.AspNetCore.Http;
using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class HRAHeader:EntityBase
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
   
        public string Plant { get; set; }
        public string Eyes { get; set; }

        public string Skin { get; set; }

        public string Ingestion { get; set; }
        public string Inhalation { get; set; }
        [Required]
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

    }

    public class FileData 
    {
        public IFormFile files { get; set; }
        public string destination { get; set; }
    }
    }

