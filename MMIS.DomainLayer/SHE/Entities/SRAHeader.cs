using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SRAHeader:EntityBase
    {
        [Required]
        public string Centre { get;  set; }
    
        public string Plant { get; set; }
        [Required]
        public string Department { get;  set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string HazardInvolved { get; set; }
        [Required]
        public string AssociatedRisk { get; set; }
        [Required]
        public string Tasks { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Severity { get; set; }
        [Required]
        public int probability { get; set; }
        [Required]
        public int RiskScore { get; set; }
        [Required]
        public bool Condition { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string SRAType { get; set; }
        [Required]

        public int ResidualProbability { get; set; }
        [Required]
        public int ResidualRiskScore { get; set; }
  
        [Required]
        public virtual ICollection<SRAControls> SRAControls { get; set; }
        [Required]
        public virtual ICollection<SRARequirements> SRARequirements { get; set; }
        



    }
}

