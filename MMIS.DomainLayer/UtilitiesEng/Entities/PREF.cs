using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class PREF : EntityBase
    {
        public string Tank_ID { get; set; }
        public decimal Glycolpressure { get; set; }
        public decimal Glycoltemperature { get; set; }
        public decimal Beertemperature { get; set; }
        public virtual ICollection<HourlyCooling> HourlyCoolings { get; set; }
    }

    public class HourlyCooling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual PREF PId { get; set; }
        public int Hour { get; set; }
        public string Name { get; set; }
        public decimal Reading { get; set; }
        public decimal CoolTemp { get; set; }
    }
}
