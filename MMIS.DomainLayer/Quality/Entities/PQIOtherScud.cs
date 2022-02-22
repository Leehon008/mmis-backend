using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PQIOtherScud : Entitybase
    {
        public DateTime Date { get; set; }
        public string BrewNo { get; set; }
        public decimal WT_ReducingSugars { get; set; }
        public decimal WT_pH { get; set; }
        public decimal WT_TotalAcids { get; set; }
        public decimal WT_Ref { get; set; }
        public decimal WT_Viscosity { get; set; }
        public decimal H24_pH { get; set; }
        public decimal H24_ReducingSugars { get; set; }
        public decimal H24_TotalAcids { get; set; }
        public decimal H24_Alcohol { get; set; }
        public decimal H24_Viscosity { get; set; }
        public decimal H48_pH { get; set; }
        public decimal H48_TotalAcids { get; set; }
        public decimal H48_Alcohol { get; set; }
        public decimal H48_Viscosity { get; set; }
        public decimal H48_HeadSize { get; set; }
        public decimal H48_Settling { get; set; }
        public decimal H72_pH { get; set; }
        public decimal H72_TotalAcids { get; set; }
        public decimal H72_Alcohol { get; set; }
        public decimal H72_Viscosity { get; set; }
        public decimal H120_TotalAcids { get; set; }
        public decimal H120_Alcohol { get; set; }
        public decimal H120_Viscosity { get; set; }
        public decimal Age045acids { get; set; }
        public string Colour { get; set; }
        public decimal Organoleptic72 { get; set; }
        public decimal PackagingAge { get; set; }
        public decimal MP_TotalAcids { get; set; }
        public decimal MP_Alcohol { get; set; }
        public decimal MP_Viscosity { get; set; }
    }
}
