using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Analyst { get; set; }
        public DateTime Date { get; set; }
    }

    public class EntityBasePlant : EntityBase
    {
        public string Plant { get; set; }
    }
}
