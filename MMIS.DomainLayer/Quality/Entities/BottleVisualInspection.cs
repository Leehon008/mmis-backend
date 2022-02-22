using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class BottleVisualInspection : Entitybase
    {
        public DateTime Date { get; set; }
        public bool FlashOvalNeck { get; set; }
        public bool ShortShot { get; set; }
        public bool Bridging { get; set; }
        public bool OffCentre { get; set; }
        public bool Haziness { get; set; }
        public bool UnderBlown { get; set; }
        public bool Stability { get; set; }
        public bool Craters { get; set; }
        public bool HolesCracks { get; set; }
        public bool Partingline { get; set; }
        public bool Threadformation { get; set; }
        public bool Misalignment { get; set; }
        public bool Contamination { get; set; }
        public bool Colour { get; set; }
        public bool GoNoGoGauge { get; set; }
        public bool Degating { get; set; }
        public bool Capfit { get; set; }
        public bool Height { get; set; }
        public decimal BBTViscosity { get; set; }
    }
}
