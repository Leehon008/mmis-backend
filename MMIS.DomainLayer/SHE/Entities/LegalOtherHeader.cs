using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class LegalOtherHeader : EntityBase
    {
     
        public string Center { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Category { get; set; }
       
       [Required]
        public string CreatedBy { get; set; }
      
        public string Plant { get; set; }


        public virtual ICollection<LegalOtherRequirements> LegalOtherRequirements { get; set; }


    }
}

