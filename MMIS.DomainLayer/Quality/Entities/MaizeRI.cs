using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class MaizeRI
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Analyst { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Supplier { get; set; }
        public string TruckNum { get; set; }
        public string SiloOffloadedInto { get; set; }
        public decimal Quantity { get; set; }
        public decimal Moisture { get; set; }
        public decimal Chipped { get; set; }
        public decimal Defective { get; set; }
        public decimal TotalDensity { get; set; }
        public decimal Trash { get; set; }
        public decimal ExtraMatter { get; set; }
        public decimal WeevilsInfestationLive { get; set; }
        public decimal WeevilsInfestationDead { get; set; }
        public string Extract { get; set; }
        public string Colour { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}
