using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class LossWasteHeader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Plant { get; set; }
        public string ShiftNo { get; set; }
        public string LWId { get; set; }
        public string ReportingLine { get; set; }
        public string LineStatus { get; set; }
        public double HourlyTPV { get; set; }
        public double LostTime { get; set; }
        public DateTime CreatedOn { get;  set; }
        public DateTime TimeEntered {get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int ShiftStatus { get; set; }
        public int ShiftInterval { get; set; }
        public string Comment { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int ApprovalStatus { get; set; }
        public virtual ICollection<LossWasteFaults> LWFault { get; set; }
   

    }
}