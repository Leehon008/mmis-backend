using MMIS.DomainLayer.Entities.Shared;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class Lines: EntityBase
    {
        public string LineId { get; set; }
        public string LineName { get; set; }
        public string LineGroupId { get; set; }

        public double LineRating { get; set; }
        public string PlantId { get; set; }

        public string Pack { get; set; }

    }
}

