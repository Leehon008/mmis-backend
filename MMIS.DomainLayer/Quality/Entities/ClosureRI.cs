using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ClosureRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public int Sample { get; set; }
        public decimal Mass { get; set; }
        public decimal Height { get; set; }
        public decimal Diameter { get; set; }
        public string TemperEvidenceBand { get; set; }
        public string Printing { get; set; }
        public string Color { get; set; }
    }
}