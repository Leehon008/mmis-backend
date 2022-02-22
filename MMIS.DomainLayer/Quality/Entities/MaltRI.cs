using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class MaltRI : EntityBaseCOA
    {
        public string DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public decimal Moisture { get; set; }
        public decimal SDU { get; set; }
        public decimal Solubility { get; set; }
        public decimal MaltActivity { get; set; }
        public decimal Extract { get; set; }
        public decimal TBC { get; set; }
        public string SandDetection { get; set; }
        public decimal FreeAminoNitrogen { get; set; }
    }
}
