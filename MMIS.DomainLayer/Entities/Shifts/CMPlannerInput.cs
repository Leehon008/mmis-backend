using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class CMPlannerInput
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string IDNo { get; private set; }
        public string ShiftNo { get; set; }
        public string area { get; set; }
        public string location { get; set; }
        public string Issue { get; set; }
        public string WoNumber { get; set; }
        public string notification { get; set; }
         public string byWho { get; set; }
        public DateTime byWhen { get; set; }
        public string planner { get; set; }
         public DateTime CreatedOn { get;private set; }

        public string Createdby { get; set; }
        

    }
}

