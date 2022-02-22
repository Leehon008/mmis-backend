using MMIS.DomainLayer.ManDev;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Deviations.Entities
{
    public class Notification : EntityBase
    {
        public string Function { get; set; }
        public string DCT { get; set; }
        public string Notice { get; set; }
    }
}
