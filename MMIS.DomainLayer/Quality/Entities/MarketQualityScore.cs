using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class MarketQualityScore : Entitybase
    {
        public string Outlet { get; set; }
        public DateTime Date { get; set; }
        public int BeerStorageArea { get; set; }
        public int ProductAvailability125L { get; set; }
        public int BeerAvailability1LSuper { get; set; }
        public int ProductAvailability15L { get; set; }
        public int StockRotation { get; set; }
        public int ProductPresentation { get; set; }
        public int Shrinkfilm { get; set; }
        public int Bottles { get; set; }
        public int Closures { get; set; }
        public int Accessibility { get; set; }
        public int Total { get; set; }
        public decimal Score { get; set; }
        public virtual ICollection<MQSSuper> MQSSuper { get; set; }
        public virtual ICollection<MQSScud> MQSScud { get; set; }
        public virtual ICollection<CompetitorProduct> CompetitorProducts { get; set; }
        public string OverallComments { get; set; }
        public string Assessor { get; set; }
    }

    public class MQSSuper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual MarketQualityScore MQS { get; set; }
        public string Batch { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PackSize { get; set; }
        public int TotalAcids { get; set; }
        public int Viscosity { get; set; }
        public int Alcohol { get; set; }
        public int Colour { get; set; }
        public int Co2 { get; set; }
        public int Organoleptic { get; set; }
        public int Torque { get; set; }
        public int Taste { get; set; }
        public int Expiry { get; set; }
        public int Total { get; set; }
        public decimal Score { get; set; }

    }

    public class MQSScud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual MarketQualityScore MQS { get; set; }
        public string Batch { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PackSize { get; set; }
        public int TotalAcids { get; set; }
        public int Viscosity { get; set; }
        public int Alcohol { get; set; }
        public int Taste { get; set; }
        public int Expiry { get; set; }
        public int Total { get; set; }
        public decimal Score { get; set; }

    }

    public class CompetitorProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual MarketQualityScore MQS { get; set; }
        public string Name { get; set; }
        public string Presentability { get; set; }
        public string PresentabilityComment { get; set; }
        public decimal TotalAcids { get; set; }
        public string TotalAcidsComment { get; set; }
        public decimal Viscosity { get; set; }
        public string ViscosityComment { get; set; }
        public decimal Alcohol { get; set; }
        public string AlcoholComment { get; set; }
        public string TasteTest { get; set; }
        public string TasteTestComment { get; set; }
    }
}
