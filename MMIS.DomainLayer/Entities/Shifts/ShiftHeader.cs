using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class ShiftHeader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get;  set; }
        public string ShiftNo { get;  set; }
        public string ReportingLine { get; set; }
        public double MRC { get; set; }
        public string ShiftName { get; set; }
        public string ShiftLeader { get; set; }
        public string ShiftGroupId { get; set; }
        public int StatusId { get; set; }
        public string PlantId { get; set; }
        public DateTime ShiftStartDate { get; set; }
        public DateTime ShiftEndDate { get; set; }
        public string ChangedBy { get; set; }
        public double TargetVolume { get; set; }
        public double PaidFactoryHours { get; set; }
        public double StandardHours { get; set; }
        public double StdAdjustedHours { get; set; }
        public double StdOperatingHours { get; set; }
        public double StdProcessingHours { get; set; }
        public DateTime CreatedOn { get;  set; }
        public DateTime ModifiedOn { get; set; }       
        public bool Status { get; set; }
        public virtual ICollection<LWInterval> LWIntervals { get; set; }     
        public virtual ICollection<ShiftMeetingActions> shiftMeeting { get; set; }
        public virtual ICollection<ShiftAttendence> shifAttendence { get; set; }



    }

    public class LWInterval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual ShiftHeader SH { get; set; }
        public int Interval { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Length { get; set; }
        public bool Status { get; set; }
    }

    public class ShiftStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string StatusId { get; set; }
        public string  Status { get; set; }
    }
}

