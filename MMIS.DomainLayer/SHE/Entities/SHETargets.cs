using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SHETargetsHeader : EntityBase
    {

        public string Objective { get; set; }
        [Required]
  
        public string Programme { get; set; }
        [Required]
        public string ActionPlan { get; set; }
        [Required]
        public string Resources { get; set; }
        [Required]
        public string Indicators { get; set; }
       
        [Required]
        public DateTime TargetStartDate { get; set; }
        [Required]
        public DateTime TargetEndDate { get; set; }
        [Required]

        public string Responsibility { get; set; }
 
        public string Plant { get; set; }

        public virtual ICollection<SHETargetItems> SHETargetItems { get; set; }

        public string CreatedBy { get; set; }
    }


    public class SHETargetItems
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Target { get; set; }

        public virtual SHETargetsHeader SHETargetsHeader { get; set; }


    }




}

