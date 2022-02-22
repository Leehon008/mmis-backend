using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class ShiftAttendence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; private set;  }
        public string OperatorId { get; set; }
        public string Attendence { get; set; }
        public string Role { get; set; }
        public DateTime ShiftDate { get; set; }
        public string TimeIn { get; set; }
        public virtual ShiftHeader shiftHeader { get; set; }
    }
}

