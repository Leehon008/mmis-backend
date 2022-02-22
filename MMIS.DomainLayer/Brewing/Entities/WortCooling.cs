using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class WortCooling
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
        public decimal Duration { get; set; }
        public decimal CoolingRate { get; set; }
        public decimal CoolingTemp { get; set; }
        public decimal HWMnHECIP { get; set; }
        public decimal CollectedWortTemp { get; set; }
        public decimal WortPH { get; set; }
        public decimal PresentExtract { get; set; }
        public decimal SpecificGravity { get; set; }
        public decimal Viscosity { get; set; }
        public decimal TitratableAcidity { get; set; }
        public decimal TotalSolids { get; set; }
        public decimal MicrobiologicalContent { get; set; }
        public string Attendant { get; set; }
    }

    public class WortCoolingPE
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
        public decimal Velocity { get; set; }
        public decimal FlowMeterAccuracy { get; set; }
        public decimal CoolingCoils { get; set; }
        public decimal WaterTemp { get; set; }
        public string SamplePoint { get; set; }
        public string CIPEffectiveness { get; set; }
        public string Safety { get; set; }
        public string Attendant { get; set; }
    }
}
