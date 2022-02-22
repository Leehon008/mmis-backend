using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class Cooking
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
        public string Balling { get; set; }
        public decimal MashTemp { get; set; }
        public decimal CookerPressure { get; set; }
        public decimal HeatToBoil { get; set; }
        public decimal TempRampRate { get; set; }
        public decimal PostBoilHoldingTime { get; set; }
        public decimal StandTemp1 { get; set; }
        public decimal CIP { get; set; }
        public string Attendant { get; set; }
    }

    public class CookingPE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public decimal Vessel { get; set; }
        public decimal Headspace { get; set; }
        public decimal TempProbeAccuracy { get; set; }
        public decimal TempControlTolerance { get; set; }
        public decimal RampRateTolerance { get; set; }
        public decimal TempVariation { get; set; }
        public decimal HeatingMediumTemp { get; set; }
        public string HeatingJackets { get; set; }
        public string AgitatorStart { get; set; }
        public decimal AgitatorTopSpeed { get; set; }
        public string HeatLossControl { get; set; }
        public string HomogenousMash { get; set; }
        public string SamplePoint { get; set; }
        public string CIPEffectiveness { get; set; }
        public string Safety { get; set; }
        public string Attendant { get; set; }
    }
}
