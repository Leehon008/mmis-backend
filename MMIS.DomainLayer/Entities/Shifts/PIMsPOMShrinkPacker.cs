using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class PIMsPOMShrinkPacker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; set; }
        public double BladeCutting { get; set; }
        public double SensorPositioning { get; set; }
        public double ShrinkpackerMachineSpeedLine2 { get; set; }
        public double BarCompressorPressure { get; set; }
        public double ShrinkpackerMachineSpeedLine3 { get; set; }
        public double SkewedPacks { get; set; }
        public double ElectricalCabinets { get; set; }
        public double OvenTemperature { get; set; }
        public double UnevenEyes { get; set; }
        public double UnwrappedBottles { get; set; }
        public double CasesProduced { get; set; }
        public double NoCasesRejected { get; set; }

        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get;private set; }
      

    }
}

