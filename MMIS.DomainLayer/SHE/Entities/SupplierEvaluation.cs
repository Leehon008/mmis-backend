using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SupplierEvaluation : EntityBase
    {
        [Required]
        public string RefNo { get;  set; }
        [Required]
        public string ScopingArea { get;  set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public double TotalScore { get; set; }
        [Required]
        public string AuditFindings { get; set; }
        public string CreatedBy { get; set; }


        public string Plant { get; set; }


    }
}

    

