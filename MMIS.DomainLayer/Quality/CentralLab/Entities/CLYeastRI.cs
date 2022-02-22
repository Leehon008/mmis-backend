using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLYeastRI : EntityBase
    {
        public string BatchNumber { get; set; }
        public string Moisture { get; set; }
        public string Liveyeast { get; set; }
        public string TBC { get; set; }
        public string Lactobacilli { get; set; }
        public string WildYeast { get; set; }
        public string Coliforms { get; set; }
        public string EColi { get; set; }
        public string Viability { get; set; }
    }
}
