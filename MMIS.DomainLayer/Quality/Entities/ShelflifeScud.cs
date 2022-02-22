using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ShelflifeScud : Entitybase
    {
        public string BatchNumber { get; set; }
        public string Silo { get; set; }
        public string Tank { get; set; }
        public string Brew { get; set; }
        public string MaltBatch { get; set; }
        public string YeastBatch { get; set; }
        public string TRS { get; set; }
        public virtual ICollection<SLParametersScud> Parameters { get; set; }
    }

    public class SLParametersScud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public decimal Visc { get; set; }
        public decimal pH { get; set; }
        public decimal TotalAcids { get; set; }
        public decimal Head { get; set; }
        public decimal Sett { get; set; }
        public decimal Alcohol { get; set; }
        public decimal Brix { get; set; }
        public decimal SG { get; set; }
        public decimal OE { get; set; }
        public decimal RDF { get; set; }
        public string Taste { get; set; }
        public decimal Temp { get; set; }
        public string Analyst { get; set; }
        public virtual ShelflifeScud SL { get; set; }

    }
}
