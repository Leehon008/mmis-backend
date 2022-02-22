using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLFOC : EntityBase
    {
        public string Plant { get; set; }
        public string Reference { get; set; }
        public string NatureOfComplaint { get; set; }
        public string Result { get; set; }
    }
}
