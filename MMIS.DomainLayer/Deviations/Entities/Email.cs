using MMIS.DomainLayer.ManDev;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Deviations.Entities
{
    public class DeviationEmail : EntityBase
    {
        public string Function { get; set; }
        public string DCT { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Cc { get; set; }
    }
}
