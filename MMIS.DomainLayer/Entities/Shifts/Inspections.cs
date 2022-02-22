using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class Inspections
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }

        public string ShiftNo { get; set; }

        public string Plant { get; set; }
        public string LineId { get; set; }
        public string Machine { get; set; }
        public string WODescription { get; set; }
      
        public string WONumber { get; set; }
        public string WOLevel { get; set; }
        public string AssignedTo { get; set; }
        public double TargetDuration { get; set; }
        
        public string Status { get; set; }
        public string WorkArising { get; set; }
        public DateTime CreatedOn { get;private set; }

        public string Createdby { get; set; }


    }
}

