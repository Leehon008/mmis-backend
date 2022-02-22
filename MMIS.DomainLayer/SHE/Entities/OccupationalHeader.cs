using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class OccupationalHeader : EntityBase
    {
        [Required]
        public string Centre { get;  set; }
        [Required]

        public string Department { get;  set; }
  
        public string Plant { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Hazard { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string AssociatedRisk { get; set; }
        [Required]
        public int NoOfShifts { get; set; }
        [Required]

        public int HoursExposed { get; set; }
        [Required]
        public int RequiredOEL { get; set; }
        [Required]
        public int MeasuredOEL { get; set; }
        [Required]
        public string OperationalCondition { get; set; }
        [Required]
        public int Severity        { get; set; }
        [Required]
        public int Frequency        { get; set; }
        [Required]
        public int NoOfPeopleExposed { get; set; }

        [Required]
        public int Probability   { get; set; }

        [Required]
        public int ResidualFrequency { get; set; }
        [Required]
        public int ResidualProbability { get; set; }
        [Required]
        public int ResidualRiskScore { get; set; }
        [Required]
        public int ResidualNoOfExposedPeople {get; set; }
        [Required]
        public int RiskScore { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
    
        public virtual ICollection<OccupationalControls> OccupationalControls { get; set; }
        [Required]
        public virtual ICollection<OccupationalRequirements> OccupationalRequirements { get; set; }





    }
}

