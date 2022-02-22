using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class CoolTo54
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
        public decimal MashThickness { get; set; }
        public decimal QuenchingWaterTemp { get; set; }
        public decimal FinalTemp { get; set; }
        public string ExogenousEnzymes { get; set; }
        public decimal RampRate { get; set; }
        public decimal Calcium { get; set; }
        public string CIPEffectiveness { get; set; }
        public string Attendant { get; set; }
    }

    public class Conversion
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
        public string Stage { get; set; }
        public decimal PH { get; set; }
        public decimal PresentExtract { get; set; }
        public decimal Viscosity { get; set; }
        public string Attendant { get; set; }
    }


    public class ConversionPE
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
        public decimal VesselHeadspace { get; set; }
        public decimal TempProbe { get; set; }
        public decimal TempControlTolerance { get; set; }
        public decimal HeatingMediumTemp { get; set; }
        public decimal RampRateTolerance { get; set; }
        public string HeatingJackets { get; set; }
        public string HeatControl { get; set; }
        public decimal AgitatorStart { get; set; }
        public string SamplingPoint { get; set; }
        public decimal TempControlVariation { get; set; }
        public string HomogenousMash { get; set; }
        public decimal AgitatorTipSpeed { get; set; }
        public decimal TransferTime { get; set; }
        public decimal MashTransferVelocity { get; set; }
        public decimal CIP { get; set; }
        public string CIPEffectiveness { get; set; }
        public string Safety { get; set; }
        public string Attendant { get; set; }
    }
}
