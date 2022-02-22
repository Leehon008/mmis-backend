using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class BrewingProcessTimeStds
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Plant { get; set; }
        public string ProcessId { get; set; }
        public string Process { get; set; }

        public string Country { get; set; }
        public string BrewProcessType { get; set; }
        public string Product { get; set; }
        public int Target { get; set; }
    }
}
