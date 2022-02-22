using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class OverseerInput : EntityBase
    {
        public string RiskAssessmentNumber { get; set; }
        public decimal CleaningDuration { get; set; }
        public decimal FactoryCapacity { get; set; }
        public string MachineDowntimeType { get; set; }
    }
}
