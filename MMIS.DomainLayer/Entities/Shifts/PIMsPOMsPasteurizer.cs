using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class PIMsPOMsPasteurizer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; set; }
        public double PasterisationUnits { get; set; }
        public double IncomingGlycolTemperature { get; set; }
        public double IncomingCo2Pressure { get; set; }
        public double IncomingSteamPressure { get; set; }
        public double PasteurisingTemperatures { get; set; }
        public double BufferLevel { get; set; }
        public double BeerViscosity { get; set; }
        public double Torques { get; set; }
        public double Co2InBottle { get; set; }
        public double PasteuriserBeerTemperature { get; set; }
        
        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get;private set; }

        }
}

