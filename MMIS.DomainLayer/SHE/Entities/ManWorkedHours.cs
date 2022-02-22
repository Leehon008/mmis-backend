using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ManWorkedHours : EntityBase
    {
       
        public string Plant { get;  set; }
        
        public DateTime WeekStartDate   { get;  set; }
        
        public DateTime WeekEndDate { get; set; }
        public double ManHoursWorked { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

