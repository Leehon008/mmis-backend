using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class IssueBasedRAHeader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string DocumentNo { get; private set; }
        public string Location { get;  set; }
        public DateTime Date { get; set; }
        public string Task { get; set; }
        public string AssessmentNumber { get; set; }
    
        public string Plant { get; set; }
        public DateTime CreatedOn { get;private set; }
        public string CreatedBy { get; set; }
    
        public virtual ICollection<IssueBasedRAItems> IssueBasedRAItems { get; set; }
        public virtual ICollection<IssueBasedRAMembers> IssueBasedRAMembers { get; set; }
        public virtual ICollection<IssueBasedRAAuthorisations> IssueBasedRAAuthorisations { get; set; }


    }
}

