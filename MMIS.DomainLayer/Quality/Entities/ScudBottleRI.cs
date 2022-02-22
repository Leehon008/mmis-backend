using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ScudBottleRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public decimal CavityNumber { get; set; }
        public decimal Mass { get; set; }
        public decimal TotalBottleHeight { get; set; }
        public decimal NODPThread { get; set; }
        public decimal NODNThread { get; set; }
        public decimal NODRatchettoratchet { get; set; }
        public decimal Neckheightratchet { get; set; }
        public decimal Neck { get; set; }
        public decimal RatchetHeight { get; set; }
        public decimal NeckInsidediameter { get; set; }
        public decimal Bottleridgediameter { get; set; }
    }
}