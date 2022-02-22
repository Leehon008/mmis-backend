using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class BrewingFermentation
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
        public decimal FermentationTemp { get; set; }
        public decimal Volume { get; set; }
        public decimal Age { get; set; }
        public string ColdCIP { get; set; }
        //Chibuku
        public decimal Temperature { get; set; }
        public decimal Taste { get; set; }
        //Super
        public decimal Occupancy { get; set; }
        public decimal FPMDeviation { get; set; }
        public decimal FPMPresentExtract { get; set; }
        //End Super
        public string Attendant { get; set; }
    }

    public class FermentationPE
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
        public decimal HeightToDiameter { get; set; }
        public decimal MaxFVDiameter { get; set; }
        public decimal TempProbePA { get; set; }
        public decimal NumberTempProbes { get; set; }
        public decimal PositionTempProbes { get; set; }
        public decimal NumberCoolingJackets { get; set; }
        public decimal PositionCoolingJackets { get; set; }
        public string Agitation { get; set; }
        public string SamplePoint { get; set; }
        public string CIPEffectiveness { get; set; }
        public string Safety { get; set; }
        public string Attendant { get; set; }
    }
}
