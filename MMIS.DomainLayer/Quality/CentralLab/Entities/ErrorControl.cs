using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class ErrorControl : EntityBase
    {
        public string Plant { get; set; }
        public string PAnalyst { get; set; }
        public decimal PH { get; set; }
        public decimal REF { get; set; }
        public decimal Alcohol { get; set; }
        public decimal TAcids { get; set; }
    }

    public class ErrorControlScud : ErrorControl
    {
        public decimal TRS { get; set; }

    }

    public class ErrorControlSuper : ErrorControl
    {
        public decimal BRIX { get; set; }
    }


}
