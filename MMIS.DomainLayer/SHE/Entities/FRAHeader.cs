using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class FRAHeader : EntityBase
    {
        [Required]
        public string Centre { get;  set; }
        [Required]
        public string Department { get;  set; }
      
      
        public string Plant { get; set; }
        public string Location { get; set; }
        [Required]
        public string FireHazard { get; set; }
        [Required]
        public string IgnitionSource { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string AssociatedRisks { get; set; }
        [Required]
        public int NoOfExposedPeople { get; set; }
        [Required]

        public int Severity { get; set; }
        [Required]
        public int probability { get; set; }
        [Required]
        public int RiskScore { get; set; }
        [Required]
        public int Exposure { get; set; }
        [Required]
   
        public DateTime CreatedOn { get; set; }
        [Required]
    
        public int ResidualProbability { get; set; }
        [Required]
        public int ResidualRiskScore { get; set; }
        [Required]
       
        public string CreatedBy { get; set; }
        [Required]
    
        public virtual ICollection<FRAEquipments> FRAEquipments { get; set; }
        [Required]
        public virtual ICollection<FRAControls> FRAControls { get; set; }
        [Required]
        public virtual ICollection<FRARequirements> FRARequirements { get; set; }



    }
}

