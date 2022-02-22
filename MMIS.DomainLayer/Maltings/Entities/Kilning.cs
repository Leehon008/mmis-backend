using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class Kilning : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal KilnTemperature { get; set; }
        public decimal BoilerPressure { get; set; }
        public decimal MoistureExkiln { get; set; }
        public string KilnStartTime { get; set; }
        public string McStart { get; set; }
         


    }
}
