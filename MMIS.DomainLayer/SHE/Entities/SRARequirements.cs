using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SRARequirements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
      
        public string RequirementType { get;  set; }
  
        public string Requirement { get;  set; }
         
        public virtual SRAHeader SRAHeader { get; set; }

    }
}

