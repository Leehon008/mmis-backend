using MMIS.DomainLayer.Brewing.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class InProcessChecks
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
        public virtual ICollection<StandardCheck> StandardChecks { get; set; }
    }
    public class StartMilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string BrewNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal AdjunctMassRedSorghum { get; set; }
        public decimal MashliquorTemperature { get; set; }
        public decimal MashVolume { get; set; }
        public virtual ICollection<MillStart> Mills{ get; set; }
        public string Attendant { get; set; }
    }

    public class MillStart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public decimal AdjunctMassMaizeBuffer { get; set; }
        public decimal Mashingtime { get; set; }
        public decimal CIP { get; set; }
        public string MouldGrowth { get; set; }
        public decimal PreingMagnetCF { get; set; }
        public decimal Throughput { get; set; }
        public decimal Samplingvalve { get; set; }
        public virtual StartMilling SM { get; set; }
    }
    public class EndMilling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string BrewNumber { get; set; }
        public int StartId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal MashinginVolume { get; set; }
        public decimal MashinginTemperature { get; set; }
        public decimal Mashingintime { get; set; }
        public decimal MashResidenceCooker { get; set; }
        public virtual ICollection<MillEnd> Mills { get; set; }
        public string Attendant { get; set; }
    }

    public class MillEnd
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public decimal CrushConsistency { get; set; }
        public decimal MillPlantCF { get; set; }
        public string InsectInfestation { get; set; }
        public decimal GistComposition { get; set; }
        public decimal GristResidence { get; set; }
        public virtual EndMilling EM { get; set; }
    }

    public class Boiling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public DateTime Time { get; set; }
        public decimal RTBPressure { get; set; }
        public decimal BoilingPressure { get; set; }
        public decimal AfterBoilRef { get; set; }
        public string Attendant { get; set; }
        public virtual InProcessChecks IPC { get; set; }
    }
    public class PrimaryCooling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public DateTime Time { get; set; }
        public decimal PCWaterTemp { get; set; }
        public decimal PCWaterPH { get; set; }
        public decimal FinalMashVolume { get; set; }
        public decimal FinalMashTemp { get; set; }
        public string Attendant { get; set; }
        public virtual InProcessChecks IPC { get; set; }
    }
    public class SecondaryCooling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public DateTime Time { get; set; }
        public decimal IncomingCoolingTemp { get; set; }
        public decimal OutgoingCoolingTemp { get; set; }
        public decimal TempAtMaltAddition { get; set; }
        public string Attendant { get; set; }
        public virtual InProcessChecks IPC { get; set; }
    }
    public class MaltAddition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string BrewNumber { get; set; }
        public decimal Mass { get; set; }
        public decimal Temp { get; set; }
        public DateTime AdditionTime { get; set; }
        
        //public decimal ViscosityOfMash { get; set; }
        //public decimal TempOfMash { get; set; }
        //public decimal PHOfMash { get; set; }
        //public decimal QuantityOfWater { get; set; }
        //public decimal FinalVolume { get; set; }
        public string Attendant { get; set; }
    }
    public class Straining
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public DateTime Time { get; set; }
        public decimal ViscosityAt70Deg { get; set; }
        public decimal Temperature { get; set; }
        public decimal MaseseMoisture { get; set; }
        public decimal MaseseQuantity { get; set; }
        public decimal ViscosityAfterStraining { get; set; }
        public decimal PasteurisationTemp { get; set; }
        public string Attendant { get; set; }
        public virtual InProcessChecks IPC { get; set; }
    }
    public class StandardCheck
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public string BrewNumber { get; set; }
        public string Stage { get; set; }
        public DateTime Time { get; set; }
        public decimal Viscosity { get; set; }
        public decimal Brix { get; set; }
        public decimal SG { get; set; }
        public decimal PH { get; set; }
        public decimal Alcohol { get; set; }
        public decimal Temperature { get; set; }
        public string Attendant { get; set; }
        public virtual InProcessChecks IPC { get; set; }
    }
}
