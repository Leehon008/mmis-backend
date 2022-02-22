using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class LayerBoardsRI : EntityBaseCOA
    {
        public DateTime DateofDelivery { get; set; }
   
        public DateTime DateofManufacture { get; set; }
        public double Quantity { get; set; }
      
        public double Sample { get; set; }
        public double Width { get; set; }
        public double RepeatLength { get; set; }
        public string Colour { get; set; }
        public string Shape { get; set; }
        public string Visual { get; set; }


    }

}


