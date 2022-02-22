using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLMDD : EntityBase
    {
        public string Plant { get; set; }
        public decimal AflatoxinB1 { get; set; }
        public decimal AflatoxinB2 { get; set; }
        public decimal AflatoxinG1 { get; set; }
        public decimal AflatoxinG2 { get; set; }
        public decimal TotalAflatoxin { get; set; }

    }
}
