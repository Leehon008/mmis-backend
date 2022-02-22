using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Models.Shift
{
    public class ShiftResultDto
    {
        public List<Shifts> shift { get; set; }
        public List<Lines> line { get; set; }
        public ShiftHeader shiftHeader { get; set; }
        public List<ShiftMeetingActions> shiftMeeting { get; set; }
        public ShiftMeetingActions actionItems { get; set; }
        public List<PIMsPOMs> pimsPoms { get; set; }

        public EndShift endshift { get; set; }
        public List<Inspections> inspections { get; set; }
        public List<DIArtisanInput> artisan { get; set; }
        public List<DIPlannerInput> planner { get; set; }
        public List<CMPlannerInput> CMplanner { get; set; }
        public List<CMArtisanInput> CMArtisan { get; set; }
        public LossWasteHeader lw { get; set; }
        public PIMsPOMsCompressor compressor { get; set; }

        public PIMsPOMsBlowMoulder blowmoulder { get; set; }
        public PIMsPOMsPasteurizer pastuerizer { get; set; }
        public PIMsPOMShrinkPacker spacker { get; set; }
        public PIMsPOMsFiller filler { get; set; }
        public PIMsPOMsRobobox robobox { get; set; }


    }
}
