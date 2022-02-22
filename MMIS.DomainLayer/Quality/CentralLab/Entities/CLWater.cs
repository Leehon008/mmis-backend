using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLWater : EntityBase
    {
        public string plant { get; set; }
        public string sampleIdBefore { get; set; }
        public string sampleIdAfter { get; set; }
        public string PlateCount { get; set; }
        public string Coliforms { get; set; }
        public string EColi { get; set; }
    }
}
