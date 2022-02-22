using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class EndShift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get;  set; }
        public string StatusId { get; set; }
        public double carbondioxide { get; set; }          
        public double beerloss { get; set; }
        public double closure { get; set; }
        public double preform { get; set; }
        public double label { get; set; }
        public double glue { get; set; }
        public double shrinkwrap { get; set; }
        public double stretchwrap { get; set; }
        public DateTime ShiftEndTime  { get; set; }
        public string createdBy { get; set; }
        public DateTime CreatedOn { get; private set; }
    
    
    }
}

