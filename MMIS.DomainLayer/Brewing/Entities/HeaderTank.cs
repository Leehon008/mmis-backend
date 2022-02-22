using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class HeaderTank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public string BrewNumber { get; set; }
        public string Vessel { get; set; }
        public decimal BeerTemp { get; set; }
        public decimal CIP { get; set; }
        public decimal pH { get; set; }
        public decimal Alcohol { get; set; }
        public decimal PresentExtract { get; set; }
        public decimal SpecificGravity { get; set; }
        public decimal Viscosity { get; set; }
        public string Colour { get; set; }
        public decimal AceticAcid { get; set; }
        public decimal TitratableAcidity { get; set; }
        public string Taste { get; set; }
        public decimal DissolvedOxygen { get; set; }
        public string Agitation { get; set; }
        public string SamplePoint { get; set; }
        public string Attendant { get; set; }
    }

    public class HeaderTankPE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public string Vessel { get; set; }
        public decimal Precision { get; set; }
        public decimal Accuracy { get; set; }
        public decimal Alcohol { get; set; }
        public decimal TempProbes { get; set; }
        public decimal CoolingJackets { get; set; }
        public string Agitation { get; set; }
        public string SamplePoint { get; set; }
        public string Attendant { get; set; }
    }
}
