using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class HourlyUsageElectricity : EntityBase
    {
        public string Frequency { get; set; }
        public int Hour { get; set; }
        public string Unit { get; set; }
        public virtual ICollection<MeterReading> Readings { get; set; }
    }

    public class MeterReading
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual HourlyUsageElectricity HUId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Reading { get; set; }
        public decimal Usage { get; set; }
    }
}
