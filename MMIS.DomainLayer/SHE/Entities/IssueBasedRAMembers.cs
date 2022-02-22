using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class IssueBasedRAMembers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string DocumentNo { get; private set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
 
        public virtual IssueBasedRAHeader IssueBasedRAHeader { get; set; }

    }
}

