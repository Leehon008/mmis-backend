using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Shelflife : Entitybase
    {
        public string BatchNumber { get; set; }
        public virtual ICollection<SLParameters> Parameters { get; set; }
    }

    public class SLParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public int Day { get; set; }
        public decimal TotalAcids { get; set; }
        public decimal TasteTest { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal CO2Content { get; set; }
        public string Analyst { get; set; }
        public virtual Shelflife SL { get; set; }
    }
}
