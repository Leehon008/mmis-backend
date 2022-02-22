using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class BCOL : EntityBase
    {
        public string tank_ID { get; set; }
        public string CoolingWaterTemperature { get; set; }
        public virtual ICollection<HourlyUsageBCOL> Readings { get; set; }

    }

    public class HourlyUsageBCOL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual BCOL PId { get; set; }
        public int Hour { get; set; }
        public string Name { get; set; }
        public decimal Reading { get; set; }
        public decimal Usage { get; set; }

    }
}
