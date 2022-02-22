using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class HourlyUsageSteam : EntityBase
    {
        public string Frequency { get; set; }
        public int Hour { get; set; }
        public string Unit { get; set; }
        public string boiler_ID { get; set; }
        public virtual ICollection<MeterReadingSteam> Readings { get; set; }
    }

    public class MeterReadingSteam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual HourlyUsageSteam HUId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Receipt { get; set; }
        public decimal Reading { get; set; }
        public decimal Usage { get; set; }
    }

    public class CoalUsage : EntityBase
    {
        public string boiler_ID { get; set; }
        public decimal Usage { get; set; }
    }


}
