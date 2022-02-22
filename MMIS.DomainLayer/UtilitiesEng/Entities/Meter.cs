using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class Meter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string PID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Process { get; set; }
        public string Feed { get; set; }
        public int Level { get; set; }
        public string Frequency { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}
