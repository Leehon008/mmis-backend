using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class TrainingPlan : EntityBase
    {
        [Required]
        public string Course { get;  set; }
        [Required]
        public string Source   { get;  set; }
        [Required]
        public string TargetGroup { get; set; }
        [Required]
        public string NonfinancialResourcesRequired { get; set; }

        [Required]
        public string Cost { get; set; }
        [Required]
        public string TargetTraining { get; set; }
        [Required]
      
        public string TrainingCycle { get; set; }
        [Required]
        public string TrainingDays { get; set; }
        [Required]
        public string TrainingOrganisation { get; set; }
        [Required]
        public string Plant { get; set; }
    }
}

