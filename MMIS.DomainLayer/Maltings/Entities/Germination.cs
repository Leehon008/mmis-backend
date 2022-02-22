using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class Germination : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal Temperature { get; set; }
        public decimal ChitCount { get; set; }
        public decimal MoistureContent { get; set; }
        public string VesselNumber { get; set; }
        public string GerminationPeriod { get; set; }
        public string AirOn { get; set; }
        public string AirOff { get; set; }
        public string Sprays { get; set; }
        public string GKV { get; set; }
    }
}


