using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PackagingInProgress : Entitybase
    {
        public DateTime DateOfPacking { get; set; }
        public string PackBatch { get; set; }
        public string PackingLine { get; set; }

        public decimal CO2content { get; set; }
        public decimal Volume { get; set; }
        public decimal Torque { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal IntankViscosity { get; set; }
        public decimal InpackViscosity { get; set; }
        public decimal TotalAcids { get; set; }
        public decimal pH { get; set; }
        public decimal Brix { get; set; }
        public decimal SG { get; set; }
        public decimal Temperature { get; set; }
        public decimal PackaginGage { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public string TasteScore { get; set; }
        public virtual ICollection<PIPBrew> Brews { get; set; }
        public virtual ICollection<PIPMaterials> Materials { get; set; }
    }

    public class PIPMaterials
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Material { get; set; }
        public string BatchNumber { get; set; }
        public virtual PackagingInProgress PIP { get; set; }
    }

    public class PIPBrew
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public int BrewNumber { get; set; }
        public virtual PackagingInProgress PIP { get; set; }
    }

}
