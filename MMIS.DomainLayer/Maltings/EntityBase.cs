using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Maltings
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public string Attendant { get; set; }

    }
}
