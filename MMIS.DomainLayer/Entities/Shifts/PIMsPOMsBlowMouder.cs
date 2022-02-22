using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class PIMsPOMsBlowMoulder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; set; }
        public double AirPressure { get; set; }
        public double ChillerWaterLevel { get; set; }
        public double BlowingPressure { get; set; }
        public double AmbientRoomTemp { get; set; }
        public string LampStatus { get; set; }
        public double ChillerOutTemp { get; set; }
        public double IncomingBarPressure { get; set; }
        public double OvenTemp { get; set; }
        public double NoWaterLeaks { get; set; }
        public double NoAirLeaks { get; set; }
        public double BottleChecksDone { get; set; }
        public double NoPreformsIn { get; set; }
        public double NoPreformsOut { get; set; }
        public double NoPreformsRejected { get; set; }
        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get;private set; }

        }
}

