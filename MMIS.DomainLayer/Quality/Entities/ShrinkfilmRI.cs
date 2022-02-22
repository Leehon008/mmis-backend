using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ShrinkfilmRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public string Width { get; set; }
        public string Gauge { get; set; }
        public string CodeDiameter { get; set; }
        public string CodeShape { get; set; }
        public string ReelCondition { get; set; }
        public string Mass { get; set; }
    }
}