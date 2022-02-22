using MMIS.DomainLayer.SHE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.SHE.Models
{
    public class SHEResultDto
    {
        public PreTaskRAHeader PreTask { get; set; }
        public IssueBasedRAHeader issueBased { get; set; }
        public Appointments appointments { get; set; }
        public List<SHEResultDto> getAppointments { get; set; }
    }

}
