using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class EnvironmentalImpactControls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string ControlType { get; set; }

        public string Control { get;  set; }
  
              
        public virtual EnvironmentalImpactRAHeader EnvironmentalImpactRAHeader { get; set; }

    }
}

