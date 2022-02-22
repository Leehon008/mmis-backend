using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Entities.Shifts
{
   public class ShiftTeams : EntityBase
    {
        public string ShiftName { get; set; }
        public string Member { get; set; }
        public string Module { get; set; }
        public string Plant { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
