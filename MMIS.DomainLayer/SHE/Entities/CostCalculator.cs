using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MMIS.DomainLayer.Entities.Shared;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class CostCalculator : EntityBase
    {
        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public string ReportBy { get; set; }

        [Required]
        public string NameOfPersonInvolved { get; set; }
        [Required]
        public DateTime DateTimeOfIncident { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public virtual ICollection<ExpensesBreakDown> ExpensesBreakDown { get; set; }
    }
}
