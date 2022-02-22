using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class LabelRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public string Quantity { get; set; }
        public string Color { get; set; }
        public string Layout { get; set; }
        public string Spikes { get; set; }
        public string Overlap { get; set; }
        public string BarCode { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Direction { get; set; }
        public string Separation { get; set; }
        public string Packing { get; set; }
    }

    public class MealieMealRI : EntityBaseCOA
    {
        public DateTime DateofDelivery { get; set; }
      
        public double Quantity { get; set; }
        public string Moisture { get; set; }
        public double Mesh12 { get; set; }
        public double Mesh16 { get; set; }
        public double Mesh30 { get; set; }
        public string Appearance { get; set; }
        public string AnalystInitials { get; set; }

    }
}