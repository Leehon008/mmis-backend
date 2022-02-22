using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class VUsage : Entitybase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public DateTime LastCIP { get; set; }
        public bool Empty { get; set; }
    }
}
