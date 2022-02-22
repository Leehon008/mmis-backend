using MMIS.DomainLayer.Entities.Shared;
using Moq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class PIMsPOMsRobobox
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string ShiftNo { get; set; }
        public double StretchWrapperTemperature { get; set; }
        public double StretchAirPressure { get; set; }
        public double PalletiserAirPressure { get; set; }
        public double PalletsOnPalletMagazine { get; set; }
        public double LayerpadQuality { get; set; }
        public double RoboboxMachineSpeed { get; set; }
        public double PalletsProduced { get; set; }
        public double NoPalletsReworked { get; set; }
        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get;private set; }

        }
}

