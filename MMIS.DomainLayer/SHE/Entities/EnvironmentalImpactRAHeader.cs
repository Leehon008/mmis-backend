using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class EnvironmentalImpactRAHeader : EntityBase
    {
     
        public string Center { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string AspectInvolved { get; set; }
        [Required]
        public string AssociatedImpact{  get; set; }
        [Required]
        public string Category { get; set; }
    
        public string Plant { get; set; }

        [Required]
        public int Severity { get; set; }

        [Required]
        public int Probability { get; set; }

        [Required]
        public int Impact { get; set; }
        [Required]
     
        public int ResidualProbability { get; set; }
        [Required]
        public int ResidualImpact { get; set; }
    

        [Required]
        public bool Condition { get; set; }
       [Required]
        public string CreatedBy { get; set; }
        [Required]
        public virtual ICollection<EnvironmentalImpactControls> EnvironmentalImpactControls { get; set; }
        
 
        public virtual ICollection<EnvironmentalImpactRequirements> EnvironmentalImpactRequirements { get; set; }


    }
}

