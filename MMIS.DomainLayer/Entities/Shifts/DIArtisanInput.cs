using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class DIPlannerInput
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string IDNo { get; private set; }
        public string ShiftNo { get; set; }
        public string Planner { get; set; }
        public string Machine { get; set; }
        public string TagNo { get; set; }
        public string TagLevel { get; set; }
        public string TagBy { get; set; }
        public string Area { get; set; }

        public string Issue { get; set; }
        public string Notification { get; set; }
        public string Category { get; set; }
        public string ByWho { get; set; }
        public DateTime ByWhen { get; set; }
       
        public DateTime CreatedOn { get;private set; }

        public string Createdby { get; set; }


    }
}

