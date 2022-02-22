using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.CentralLab.Entities
{
    public class CLSorghumRI : EntityBase
    {
        public string BatchNumber { get; set; }
        public string Moisture { get; set; }
        public string SDU { get; set; }
        public string Solubility { get; set; }
        public string MaltActivity { get; set; }
        public string Extract { get; set; }
        public string FAN { get; set; }
        public string TBC { get; set; }
        public string Sand { get; set; }
    }
}
