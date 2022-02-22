using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Water : Entitybase
    {
        public DateTime DateTime { get; set; }
        public string Source { get; set; }
        public virtual ICollection<RawWater> RawWater { get; set; }
        public virtual ICollection<PostSandFiltration> PostSandFiltration { get; set; }
        public virtual ICollection<PostChlorination> PostChlorination { get; set; }
        public virtual ICollection<TreatedWater> TreatedWater { get; set; }
    }

    public class RawWater
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual Water Water { get; set; }
        public decimal Palkalinity { get; set; }
        public decimal Malkalinity { get; set; }
        public decimal pH { get; set; }
        public decimal TDS { get; set; }
        public decimal Turbidity { get; set; }
        public string Taintnetting { get; set; }
    }

    public class PostSandFiltration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual Water Water { get; set; }
        public decimal Palkalinity { get; set; }
        public decimal Malkalinity { get; set; }
        public decimal pH { get; set; }
        public decimal TDS { get; set; }
        public decimal Turbidity { get; set; }
        public string Taintnetting { get; set; }
    }

    public class PostChlorination
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual Water Water { get; set; }
        public decimal Chlorine { get; set; }
        public decimal Turbidity { get; set; }
        public string Taintnetting { get; set; }
    }

    public class TreatedWater
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual Water Water { get; set; }
        public decimal Residualchlorine { get; set; }
        public decimal pH { get; set; }
        public decimal Conductivity { get; set; }
        public decimal Malkalinity { get; set; }
        public decimal TDS { get; set; }
        public string Taintnetting { get; set; }
        public string Taste { get; set; }
        public decimal Turbidity { get; set; }
        public decimal Totalhardness { get; set; }
        public decimal Chloride { get; set; }
        public decimal sulphate { get; set; }
    }

    public class BulkWater : Entitybase
    {
        public DateTime DateTime { get; set; }
        public string Supplier { get; set; }
        public string TruckNumber { get; set; }
        public decimal pH { get; set; }
        public decimal TDS { get; set; }
        public decimal Hardness { get; set; }
        public decimal Turbidity { get; set; }
        public string Taintnetting { get; set; }
    }
}
