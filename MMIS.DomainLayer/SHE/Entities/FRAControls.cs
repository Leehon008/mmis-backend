using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class FRAControls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
    
        public string Control { get;  set; }
    
        public string Measure { get;  set; }

        public string ResponsiblePerson { get; set; }

        public DateTime DueDate { get; set; }

        public virtual FRAHeader FRAHeader { get; set; }

    }
}

