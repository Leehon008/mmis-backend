using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class ShakeShakeSleeve : EntityBaseCOA
    {
        public DateTime DateofDelivery { get; set; }
        public string Supplier { get; set; }
        public DateTime DateofManufacture { get; set; }
        public double Quantity { get; set; }
        public string Sample { get; set; }
        public string CartonAppearance { get; set; }
        public string Colour { get; set; }
        public string Quality { get; set; }
        public string Print { get; set; }
        public string CreaseAlignment { get; set; }
        public string SideSeam { get; set; }
        public string Visual { get; set; }

    }

}


