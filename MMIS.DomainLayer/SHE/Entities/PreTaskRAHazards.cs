using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class PreTaskRAHazards
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string HazardNo { get; private set; }
        public string FormId { get; set; }
        public string Hazard { get;  set; }
        public string Control { get; set; }

        public virtual PreTaskRAHeader PreTaskRAHeader { get; set; }
    }
}

