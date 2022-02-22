using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLCIP : EntityBase
    {
        public string plant { get; set; }
        public string sampleId { get; set; }
        public string PCA { get; set; }
        public string NBB { get; set; }
        public string WA { get; set; }
        public string WLN { get; set; }
    }
}
