using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class ShiftMeetingActions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string MeetingID { get;private set; }
        public string ShiftNo { get;private set; }
        public string ShiftName { get; set; }
        public string TaskNo { get;private set; }
        public string Task { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime ExpectedTime { get; set; }
     
         public virtual ShiftHeader shiftHeader { get; set; }
       

    }
}

