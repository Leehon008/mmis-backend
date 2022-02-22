using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class YeastRI : EntityBaseCOA
    {
        public string BestBeforeDate { get; set; }
        public string Quantity { get; set; }
        public string AlcoholProduction { get; set; }
        public string FoamFormation { get; set; }
        public string Colour { get; set; }
        public string MoistureContent { get; set; }
        public string ShelfLife { get; set; }
        public string TotalBacteria { get; set; }
        public string Lactobacillus { get; set; }
        public string WildYeast { get; set; }
        public string EColi { get; set; }
        public string Coliforms { get; set; }
        public string LiveCellCount { get; set; }
        public string Viability { get; set; }
    }
}
