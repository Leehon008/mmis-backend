using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class HRAClassification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
      
        public string Classification { get;  set; }
  
              
        public virtual HRAHeader HRAHeader { get; set; }

    }
}

