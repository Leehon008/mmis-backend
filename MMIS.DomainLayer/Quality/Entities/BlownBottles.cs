using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class BlownBottles : Entitybase
    {
        public DateTime Date { get; set; }
        public string Line { get; set; }
        public virtual ICollection<BlownBottleDim> BBDimensions { get; set; }
    }

    public class BlownBottleDim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual BlownBottles BBId { get; set; }
        public decimal MouldCavity { get; set; }
        public decimal NeckShoulder { get; set; }
        public decimal LabelPanel { get; set; }
        public decimal Heel { get; set; }
        public decimal TotalMass { get; set; }
    }
}
