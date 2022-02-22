using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class PIMsPOMs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; set; }
    
        public string Machine { get; set; }
        public string Dimension { get; set; }
      
        public string Value { get; set; }
        public string UoM { get; set; }
        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get;private set; }

        }
}

