using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class HourlyUsageWater : EntityBase
    {
        public string Frequency { get; set; }
        public int Hour { get; set; }
        public string Unit { get; set; }
        public virtual ICollection<WaterMeterReading> Readings { get; set; }
    }

    public class WaterMeterReading
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual HourlyUsageWater HUId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Reading { get; set; }
        public decimal Usage { get; set; }
    }
}
