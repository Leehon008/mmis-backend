using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ConfinedSpaces : EntityBase
    {
        [Required]
        public string Description { get;  set; }
        [Required]
        public string Location { get;  set; }
        [Required]
        public int NumberOfEntryPoints { get; set; }
      
        public string Plant { get; set; }
        [Required]
        public string ContinuousOccupancy { get; set; }
        [Required]
        public string RestrictedAccess { get; set; }
        [Required]
        public string LargeEnough { get; set; }
        [Required]
        public string SeriousHazards { get; set; }
        [Required]
        public string Pwt { get; set; }
        [Required]
        public DateTime DateReviewed { get; set; }
        [Required]
        public DateTime DateAccessed { get; set; }
        [Required]
        public string PotentialHazards { get; set; }
        [Required]
             
        public string CreatedBy { get; set; }
     



    }
}

    

