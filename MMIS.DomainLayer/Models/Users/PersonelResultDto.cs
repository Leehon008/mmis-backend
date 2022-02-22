using MMIS.DomainLayer.Entities.Users;
using System.Collections.Generic;

namespace MMIS.DomainLayer.Models.Users
{
    public class PersonnelResultDto
    { 
        public List<Operators> ops { get; set; }
        public List<TeamLeaders> teamLeaders { get; set; }

    }
}
