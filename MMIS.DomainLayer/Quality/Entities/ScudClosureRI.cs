using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ScudClosureRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public int Quantity { get; set; }
        public decimal CavityNumber { get; set; }
        public decimal Mass { get; set; }
        public decimal TotalInsideDiameter { get; set; }
        public decimal BandOutsideDiameter { get; set; }
        public decimal OutsideDiameter { get; set; }
        public decimal TotalClosureHeight { get; set; }
        public decimal BandHeight { get; set; }
        public decimal SlitSize { get; set; }
        public decimal InsideDiameterToFeathering { get; set; }
        public decimal FeatheringExternalDiameter { get; set; }
        public string VisualInspection { get; set; }
        public string Colour { get; set; }
        public string ColourDispersion { get; set; }
        public string Trimming { get; set; }
        public string Cracks { get; set; }
        public string symmetry { get; set; }
        public string Contaminants { get; set; }
        public string Embossing { get; set; }
        public string Dating { get; set; }
        public string Leaktest { get; set; }
        public string ClosureBottlefit { get; set; }
        public string ClosureBottleGrip { get; set; }
        public string DropTest { get; set; }
    }
}