using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLMaizeRI : EntityBase
    {
        public string Plant { get; set; }
        public string TestDensity { get; set; }
        public string Extract { get; set; }
        public string Fats { get; set; }
    }
}
