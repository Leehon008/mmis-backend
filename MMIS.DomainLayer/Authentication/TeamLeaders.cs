using MMIS.DomainLayer.Entities.Shared;

namespace MMIS.DomainLayer.Authentication
{
    public class TeamLeaders: EntityBase
    {
        public string TeamLeaderId   { get; set; }
        public string TeamLeaderName   { get; set; }
        public string TeamLeaderGroupId    { get; set; }
        public string PlantId { get; set; }
           
       
       
    }
}

