using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class SorghumGrain : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal Moisture { get; set; }
        public decimal Unthreashed { get; set; }
        public decimal Chipped { get; set; }
        public decimal ForeginMatter { get; set; }
        public decimal GerminativeCapacity { get; set; }
        public decimal Infestation { get; set; }
        public decimal PreGermination { get; set; }
        public decimal Defective { get; set; }
    }
}
