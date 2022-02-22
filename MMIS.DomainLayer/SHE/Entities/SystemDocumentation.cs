using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SystemDocumentation : EntityBase
    {
        [Required]
        public string Category { get;  set; }
        [Required]
        public string DocumentNumber { get;  set; }
        [Required]
        public string IssueNumber { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string CreatedBy { get; set; }

        public string Procedure { get; set; }
        public string Plant { get; set; }


    }
}

    

