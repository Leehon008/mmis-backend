using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class SuperBBT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string BrewNumber { get; set; }
        public DateTime Time { get; set; }
        public decimal TTTime { get; set; }
        public decimal BeerAges { get; set; }
        public decimal BlendingTime { get; set; }
        public decimal BlendVolume { get; set; }
        public decimal BeerLoss { get; set; }
        public decimal BeerTemp { get; set; }
        public string Attendant { get; set; }
    }
}
