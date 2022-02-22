using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class SRAControls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
    
        public string Control { get;  set; }
    
        public string Measure { get;  set; }
         
        public virtual SRAHeader SRAHeader { get; set; }

    }
}

