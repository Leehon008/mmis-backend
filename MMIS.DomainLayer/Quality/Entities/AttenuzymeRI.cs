using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class AttenuzymeRI : EntityBaseCOA
    {
        public DateTime DateofDelivery { get; set; }

        public DateTime DateofManufacture { get; set; }
        public string Quantity { get; set; }
        public string Sample { get; set; }
        public string Density { get; set; }
        public string ColiformBacteria { get; set; }
        public string Ecoli { get; set; }
        public string Yeast { get; set; }
        public string BeerSpoilageBacteria { get; set; }
        public string Mold { get; set; }
        public string Visual { get; set; }

    }

}


