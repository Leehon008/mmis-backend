using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class PackagingInProgressDto : ModelBase
    {
        public int Id { get; set; }
        public DateTime DateOfPacking { get; set; }
        public virtual ICollection<PIPBrewDto> Brew {get;set;}
        public virtual ICollection<PIPMaterialsDto> Materials { get; set; }
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

    }

    public class PIPMaterialsDto
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string BatchNumber { get; set; }
        public PackagingInProgressDto PIP { get; set; }
    }

    public class PIPBrewDto
    {
        public int Id { get; set; }
        public int BrewNumber { get; set; }
        public PackagingInProgressDto PIP { get; set; }
    }

}
