using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class Suppliers : EntityBase
    {
        [Required]
        public string SupplierName { get;  set; }
        [Required]
        public string Description { get;  set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public int EvaluationScore { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string Decision { get; set; }
        public string CreatedBy { get; set; }

     
        public string Plant { get; set; }


    }
}

    

