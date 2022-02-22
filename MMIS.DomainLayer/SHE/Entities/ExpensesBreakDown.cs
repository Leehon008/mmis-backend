using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ExpensesBreakDown : EntityBase
    {
        [Required]
        public string ExpenseGroup { get; set; }
        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public string IncidentNumber { get; set; }


        [Required]
        public int TimeSpent { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}
