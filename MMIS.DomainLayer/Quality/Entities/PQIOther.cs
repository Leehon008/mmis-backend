using System;
using System.Collections.Generic;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class PQIOther : Entitybase
    {
        public DateTime Date { get; set; }
        public  string BrewNo { get; set; }
        public decimal WT_pH { get; set; }
        public decimal WT_TotalAcids { get; set; }
        public decimal WT_Ref { get; set; }
        public decimal WT_Brix { get; set; }
        public decimal WT_Viscosity { get; set; }
        public decimal H12_pH { get; set; }
        public decimal H12_TotalAcids { get; set; }
        public decimal H12_Ref { get; set; }
        public decimal H12_Brix { get; set; }
        public decimal H12_Alcohol { get; set; }
        public decimal H12_SpecificGravity { get; set; }
        public decimal H12_RDF { get; set; }
        public decimal H12_Viscosity { get; set; }
        public decimal H24_pH { get; set; }
        public decimal H24_TotalAcids { get; set; }
        public decimal H24_Ref { get; set; }
        public decimal H24_Brix { get; set; }
        public decimal H24_Alcohol { get; set; }
        public decimal H24_SpecificGravity { get; set; }
        public decimal H24_RDF { get; set; }
        public decimal H24_Viscosity { get; set; }
        public decimal H48_pH { get; set; }
        public decimal H48_TotalAcids { get; set; }
        public decimal H48_Brix { get; set; }
        public decimal H48_Alcohol { get; set; }
        public decimal H48_SpecificGravity { get; set; }
        public decimal H48_RDF { get; set; }
        public decimal H48_Viscosity { get; set; }
        public decimal H72_pH { get; set; }
        public decimal H72_TotalAcids { get; set; }
        public decimal H72_Brix { get; set; }
        public decimal H72_Alcohol { get; set; }
        public decimal H72_SpecificGravity { get; set; }
        public decimal H72_Viscosity { get; set; }
        public decimal Age035acids { get; set; }
        public string Colour { get; set; }
        public string Creaminess { get; set; }
        public decimal PackagingAge { get; set; }
        public decimal BBTViscosity { get; set; }
        public decimal PIP_pH { get; set; }
        public decimal PIP_TotalAcids { get; set; }
        public decimal PIP_Brix { get; set; }
        public decimal PIP_Alcohol { get; set; }
        public decimal PIP_SpecificGravity { get; set; }
        public decimal PIP_Viscosity { get; set; }
        public decimal PIP_Co2 { get; set; }
        public decimal PIP_FillVolume { get; set; }
        public decimal PIP_Torque { get; set; }
        public decimal MP_pH { get; set; }
        public decimal MP_TotalAcids { get; set; }
        public decimal MP_Alcohol { get; set; }
        public decimal MP_SpecificGravity { get; set; }
        public decimal MP_Viscosity { get; set; }
        public decimal MP_CO2 { get; set; }
    }
}
