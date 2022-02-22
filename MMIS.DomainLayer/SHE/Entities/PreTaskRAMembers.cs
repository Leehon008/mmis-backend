using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class PreTaskRAMembers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string MemberNo { get; private set; }
        public string FormId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
    
        public bool Competence { get; set; }

        public string Remarks { get; set; }

        public virtual PreTaskRAHeader PreTaskRAHeader { get; set; }



    }
}

