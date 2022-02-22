using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class FermentationDto : ModelBase
    {
        public int Id { get; set; }
        public string Tank { get; set; }
        public int BrewNo { get; set; }
        public decimal BrixAtWort { get; set; }
        public string YeastBatch { get; set; }
        public string MaltBatch { get; set; }
        public string Status { get; set; }
        public virtual ICollection<FParametersDto> Parameters { get; set; }
    }

    public class FParametersDto
    {
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
        public FermentationDto FId { get; set; }
    }
}
