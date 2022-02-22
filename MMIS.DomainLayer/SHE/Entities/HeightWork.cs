using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class HeightWork : EntityBase
    {
        [Required]
        public string Area { get;  set; }
        [Required]
        public string Rating { get;  set; }
        
        [Required]
             
        public string CreatedBy { get; set; }


        public string Plant { get; set; }

    }
}

    

