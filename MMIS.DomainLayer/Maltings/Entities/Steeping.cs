using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class Steeping : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal Tonnage { get; set; }
        public decimal WaterTemp { get; set; }
        public decimal BlowerPressure { get; set; }
        public decimal CalciumHydroxideAmount { get; set; }
        public decimal TimeSteeped { get; set; }
        public decimal WaterUsed { get; set; }
        public decimal ChitCount { get; set; }
    }
}
