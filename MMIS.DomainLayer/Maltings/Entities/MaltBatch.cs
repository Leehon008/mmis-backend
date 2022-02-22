using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Maltings.Entities
{
    public class WetEndMalt  : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal BufferVolume { get; set; }
        public string SteepTanks { get; set; }
        public decimal GKVnumber { get; set; }
        public DateTime DateSteeped { get; set; }
        public decimal TonnageSteeped { get; set; }
        public string GrainVariety { get; set; }
        public string GrainSource { get; set; }
        public string GerminationDuration { get; set; }
        public string SprayType { get; set; }
        public decimal SprayVolume { get; set; }
        public string ChitCount { get; set; }
        public string MoistureContent { get; set; }
        public string AirOn { get; set; }
        public string AirOff { get; set; }
        public DateTime DateStartKiln { get; set; }
        public decimal KilnTime { get; set; }
        public DateTime ExKilnDate { get; set; }
    }

    public class DryEndMalt : EntityBase
    {
        public string BatchNumber { get; set; }
        public decimal HMBStatus { get; set; }
        public string MillngStartTime { get; set; }
        public decimal HourlyHammerMillEfficiency { get; set; }
        public DateTime MaltMilled { get; set; }
        public string SieveAnalysis { get; set; }
        public DateTime MaltLoadedStart { get; set; }
        public DateTime MaltLoadedEnd { get; set; }
        public decimal MaltLoaded { get; set; }
        public decimal MaltDispatched { get; set; }
        public decimal MaltOnFloor { get; set; }
        public DateTime PieceMillingStartTime { get; set; }
        public DateTime PieceMillingEndTime { get; set; }
        public decimal TotalPieceMillingTime { get; set; }
        public decimal PieceTonnage { get; set; }

    }
}
