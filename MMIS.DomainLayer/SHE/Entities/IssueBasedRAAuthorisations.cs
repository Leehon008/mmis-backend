using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class IssueBasedRAAuthorisations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string DocumentNo { get; private set; }
        public bool Supervisor { get;  set; }
        public bool SHEOfficer { get; set; }
        public bool HOD { get; set; }
        public bool SHEManager { get; set; }
       
        public virtual IssueBasedRAHeader IssueBasedRAHeader { get; set; }

    }
}

