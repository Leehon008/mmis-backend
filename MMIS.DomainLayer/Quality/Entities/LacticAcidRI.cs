using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class LacticAcidRI : EntityBaseCOA
    {
        public decimal Quantity { get; set; }
        public string ExpiryDate { get; set; }
        public string Strength { get; set; }
        public string Color { get; set; }
    }
}
