using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Wort : Entitybase
    {
        public DateTime Date { get; set; }
        public int BrewNo { get; set; }
        public string MaizeSilo { get; set; }
        public string MPV { get; set; }
        public string MaltBatch { get; set; }
        public string YeastBatch { get; set; }
        public string SpentGrainMoisture { get; set; }
        public string pH { get; set; }
        public string Ref { get; set; }
        public string Viscosity { get; set; }
        public string Brix { get; set; }
        public string SG { get; set; }
        public string OE { get; set; }
        public string TotalAcids { get; set; }
        public string RDF { get; set; }
    }
}
