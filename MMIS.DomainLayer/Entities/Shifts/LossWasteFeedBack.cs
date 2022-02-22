using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class FeedBackPanevw
    {
       public string ShiftNo { get;  set; }
        public string PreviousHour { get; set; }
        public double HourlyTPV { get; set; }
        public double CumulativeTPV { get; set; }
        public int CumulativeFactoryHours { get; set; }
        public double FactoryEfficiency { get; set; }
        public double MachineEfficiency { get; set; }
      

    }
}

