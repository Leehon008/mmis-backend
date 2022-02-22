using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLWDD : EntityBase
    {
        public string Plant { get; set; }
        public string PCA { get; set; }
        public string Coliforms { get; set; }
        public string EColi { get; set; }
        public string STyphi { get; set; }
        public string VCholerae { get; set; }
    }
}
