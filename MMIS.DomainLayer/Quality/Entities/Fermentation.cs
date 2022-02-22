using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Fermentation : Entitybase
    {
        public string Tank { get; set; }
        public int BrewNo { get; set; }
        public decimal BrixAtWort { get; set; }
        public string YeastBatch { get; set; }
        public string MaltBatch { get; set; }
        public string Status { get; set; }
        public virtual ICollection<FParameters> Parameters { get; set; }
        public virtual ICollection<FParametersScud> ScudParameters { get; set; }
    }

    public class Fermentationbase : Entitybase
    {
        public string Tank { get; set; }
        public int BrewNo { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Age { get; set; }
        public decimal Viscosity { get; set; }
        public decimal TotalAcid { get; set; }
        public decimal Alcohol { get; set; }
        public decimal Temp { get; set; }
        public decimal Volume { get; set; }
        public decimal pH { get; set; }
        public decimal Ref { get; set; }
    }

    public class FermentationSuper : Fermentationbase
    {
        public decimal BrixAtWort { get; set; }
        public string YeastBatch { get; set; }
        public string MaltBatch { get; set; }
        public decimal Brix { get; set; }
        public decimal SG { get; set; }
        public decimal OE { get; set; }
        public decimal RDF { get; set; }
    }

    public class FermentationScud : Fermentationbase
    {
        public decimal Head { get; set; }
        public decimal Settling { get; set; }
        public string Taste { get; set; }
    }

    public class FParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Age { get; set; }
        public decimal Temp { get; set; }
        public decimal pH { get; set; }
        public decimal Ref { get; set; }
        public decimal Viscosity { get; set; }
        public decimal Brix { get; set; }
        public decimal SG { get; set; }
        public decimal OE { get; set; }
        public decimal Alcohol { get; set; }
        public decimal TotalAcid { get; set; }
        public decimal RDF { get; set; }
        public string Analyst { get; set; }
        public virtual Fermentation FId { get; set; }
    }

    public class FParametersScud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Age { get; set; }
        public decimal Viscosity { get; set; }
        public decimal pH { get; set; }
        public decimal Ref { get; set; }
        public decimal TotalAcid { get; set; }
        public decimal Head { get; set; }
        public decimal Settling { get; set; }

        public decimal Volume { get; set; }
        public decimal Alcohol { get; set; }
        public decimal TRS { get; set; }
        public decimal Taste { get; set; }
        public string Analyst { get; set; }
        public virtual Fermentation FId { get; set; }
    }
}
