using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PreformRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public int Sample { get; set; }
        public string Mass { get; set; }
        public string Height { get; set; }
        public string InternalDiameter { get; set; }
        public string ExternalDiameter { get; set; }
        public string Neck { get; set; }
        public string FinishGoGauge { get; set; }
        public string Visual { get; set; }
    }
}