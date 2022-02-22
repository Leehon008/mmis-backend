using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class GlueRI : EntityBaseCOA
    {
        public DateTime DateOfManufacture { get; set; }
        public decimal Quantity { get; set; }
        public string GlueCode { get; set; }
        public string BucketCondition { get; set; }
        public string Color { get; set; }
        public string BucketSize { get; set; }
    }
}