using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class OccupationalControls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
    
        public string Control { get;  set; }
    
        public string ResponsiblePerson { get;  set; }

    

        public DateTime DueDate { get; set; }

        public virtual OccupationalHeader OccupationalHeader { get; set; }

    }
}

