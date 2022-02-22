using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class BrewerShiftHandOver : EntityBase
    {


        public string ShiftNo { get; set; }
    
        public string OutgoingShiftName { get; set; }
        public DateTime ShiftDate { get; set; }
        public string SiloInUse { get; set; }
        public string MaltBatch { get; set; }
        public string  YeastBatch { get; set; }
        public string BrewNumber { get; set; }
  
        public string MPVs { get; set; }
        public string Cs { get; set; }
        public string Fs { get; set; }
        public string FermentPackagingPlan { get; set; }
        public string TankOnline { get; set; }
        public string NextOnline { get; set; }
        public string BlendingPlan { get; set; }
        public string StrainingPlan { get; set; }
        public string FaulSignalOccured { get; set; }
        public string BreakDownOccurred { get; set; }
        public string Water { get; set; }
        public string Cooling { get; set; }
        public string PowerSource { get; set; }
        public string Steam { get; set; }
        public string OutgoingBrewer { get; set; }
        public string IncomingBrewer { get; set; }
        public string IncomingShiftName { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<BrewingPlan> BrewingPlan { get; set; }
    }

    public class BrewingPlan : EntityBase
    {

        public string Vessel { get; set; }
        public string Plan { get; set; }
        public virtual BrewerShiftHandOver BrewerShiftHandOver { get; set; }

    }
    public class BrewingPAShiftHandOver : EntityBase
    {


        public string ShiftNo { get; set; }
        public string SHEConcerns { get; set; }
        public DateTime ShiftDate { get; set; }
        public string UnSafeCondtions { get; set; }
        public string MeetingRoom { get; set; }
        public string Tanks { get; set; }
        public string FloorsWalls { get; set; }

        public string SiloInUse { get; set; }
        public string MaltBatch { get; set; }
        public string YeastBatch { get; set; }
        public string MPVs { get; set; }
        public string TransferLinesTOOBH { get; set; }
        public string TransferLinesToFerment { get; set; }
       
        public string BreakDownOccurred { get; set; }
      
        
        public string Comments { get; set; }
        public virtual ICollection<BrewingRawMatQuanties> BrewingRawMatQuanties { get; set; }
        public virtual ICollection<BrewingTankStatus> BrewingTankStatus { get; set; }
        
    }

    public class BrewingRawMatQuanties: EntityBase
    {

        public string RawMaterial { get; set; }
        public int Open { get; set; }
        public int Received { get; set; }
        public int Transfer { get; set; }
        public int Used { get; set; }
        public int Theoretical { get; set; }
        public int ActualStock { get; set; }
        public int GainLoss { get; set; }
        public virtual BrewingPAShiftHandOver BrewingPAShiftHandOver { get; set; }

    }


    public class BrewingTankStatus : EntityBase
    {

        public string Tank { get; set; }
        public string Status { get; set; }
        public virtual BrewingPAShiftHandOver BrewingPAShiftHandOver { get; set; }

    }
}
