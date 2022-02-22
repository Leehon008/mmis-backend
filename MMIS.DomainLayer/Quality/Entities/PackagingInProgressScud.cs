using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PackagingInProgressScud : Entitybase
    {
        public DateTime DateOfPacking { get; set; }
        public string PackBatch { get; set; }
        public string PackingLine { get; set; }
        public decimal DetergentDosageBW { get; set; }
        public decimal DetergentDosageCW { get; set; }
        public decimal PHBottleWasher { get; set; }
        public decimal PHCrateWasher { get; set; }
        public decimal TCBottleWasher { get; set; }
        public decimal TCCrateWasher { get; set; }
        public decimal BottleCleanliness { get; set; }
        public decimal CrateCleanliness { get; set; }
        public decimal Viscosity { get; set; }
        public decimal TotalAcids { get; set; }
        public decimal FillVolumes { get; set; }
        public decimal PercentCapped { get; set; }
        //public DateTime BestBeforeDate { get; set; }
        public virtual ICollection<PIPDamagedBottles> DamagedBottles { get; set; }
        public virtual ICollection<PIPBrewScud> Brews { get; set; }
        //public virtual ICollection<PIPBadClosures> BadClosures { get; set; }
        public virtual ICollection<PIPMaterialsScud> Materials { get; set; }
    }

    public class PIPDamagedBottles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public int ChippedNeck { get; set; }
        public int ForeignBodies { get; set; }
        public int FirtyBottles { get; set; }
        public int BrokenBottles { get; set; }
        public int RodentDamaged { get; set; }
        public int Other { get; set; }
        public virtual PackagingInProgressScud PIP { get; set; }
    }

    public class PIPBadClosures
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Shift { get; set; }
        public int ShortMoulds { get; set; }
        public int Flashes { get; set; }
        public int Dimensions { get; set; }
        public int Other { get; set; }
        public virtual PackagingInProgressScud PIP { get; set; }
    }

    public class PIPMaterialsScud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Material { get; set; }
        public string BatchNumber { get; set; }
        public virtual PackagingInProgressScud PIP { get; set; }
    }

    public class PIPBrewScud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public int BrewNumber { get; set; }
        public virtual PackagingInProgressScud PIP { get; set; }
    }

}
