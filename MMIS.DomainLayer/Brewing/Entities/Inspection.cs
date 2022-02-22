using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class Inspection
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
        public string Tank { get; set; }
        public string MainValveStatus { get; set; }
        public string MainValveComment { get; set; }
        public string ByPassValveStatus { get; set; }
        public string ByPassValveComment { get; set; }
        public string ValveLeaksStatus { get; set; }
        public string ValveLeaksComment { get; set; }
        public string WaterLeaksStatus { get; set; }
        public string WaterLeaksComment { get; set; }
        public string JacketsLeaksStatus { get; set; }
        public string JacketsLeaksComment { get; set; }
        public string SaggingCoilsStatus { get; set; }
        public string SaggingCoilsComment { get; set; }
        public string BladesAndShaftStatus { get; set; }
        public string BladesAndShaftComment { get; set; }
        public string GearboxOilLeaksStatus { get; set; }
        public string GearboxOilLeaksComment { get; set; }
        public string SpeedStatus { get; set; }
        public string SpeedComment { get; set; }
        public string SpeedOfRotationStatus { get; set; }
        public string SpeedOfRotationComment { get; set; }
        public string KitchenCleanStatus { get; set; }
        public string KitchenCleanComment { get; set; }
        public string NoRustStatus { get; set; }
        public string NoRustComment { get; set; }
        public string MashStonesStatus { get; set; }
        public string MashStonesComment { get; set; }
        public DateTime LastDateOfCIP { get; set; }
        public string LastDateOfCIPComment { get; set; }
        public string SIFunctionalStatus { get; set; }
        public string SIFunctionalComment { get; set; }
        public string SISecuredStatus { get; set; }
        public string SISecuredComment { get; set; }
        public string BottomTankValveStatus { get; set; }
        public string BottomTankValveComment { get; set; }
        public string MashLineValveStatus { get; set; }
        public string MashLineValveComment { get; set; }
        public string StrainingLineValveStatus { get; set; }
        public string StrainingLineValveComment { get; set; }
        public string MainsWaterValveStatus { get; set; }
        public string MainsWaterValveComment { get; set; }
        public string SwingBendStatus { get; set; }
        public string SwingBendComment { get; set; }
        public string ProcessAttendant { get; set; }
        public string Brewer { get; set; }
        public string Maintenance { get; set; }
    }
}
