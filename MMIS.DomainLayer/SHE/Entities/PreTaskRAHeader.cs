using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class PreTaskRAHeader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string FormId { get; set; }
        public string Section { get;  set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string TeamLeader { get; set; }
        public string RefNumber { get; set; }
        public bool Competence { get; set; }
        public string Plant { get; set; }
        public DateTime CreatedOn { get;private set; }
        public string CreatedBy { get; set; }
        public string supervisor { get; set; }
        public string headOfDepartment { get; set; }
        public string sheOfficer { get; set; }
        public string sheManager { get; set; }
        public virtual ICollection<PreTaskRAMembers> PreTaskRAMembers { get; set; }
        public virtual ICollection<PreTaskRAHazards> PreTaskRAHazards { get; set; }
        public virtual ICollection<PreTaskRAEquipment> PreTaskRAEquipment { get; set; }

        public virtual ICollection<PreTaskRAPermisions> PreTaskRAPermisions { get; set; }



    }
}

