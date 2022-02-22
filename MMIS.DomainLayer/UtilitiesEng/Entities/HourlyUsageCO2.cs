using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class HourlyUsageCO2 : EntityBase
    {
        public string Frequency { get; set; }
        public int Hour { get; set; }
        public string Unit { get; set; }
        public string tank_ID { get; set; }
        public virtual ICollection<MeterReadingCO2> Readings { get; set; }
    }

    public class MeterReadingCO2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual HourlyUsageCO2 HUId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Receipt { get; set; }
        public decimal Reading { get; set; }
        public decimal Usage { get; set; }
    }
}
