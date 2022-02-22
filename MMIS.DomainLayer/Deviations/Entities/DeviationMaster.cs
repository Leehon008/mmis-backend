using MMIS.DomainLayer.ManDev;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Deviations.Entities
{
    public class DeviationMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Function { get; set; }
        public string DCT { get; set; }
        public string Param { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public double LV { get; set; }
        public double LS { get; set; }
        public double Std { get; set; }
        public double HS { get; set; }
        public double HV { get; set; }
        public string SV { get; set; }
    }

    public class DeviationTemp
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Plant { get; set; }
        public string Function { get; set; }
        public string DCT { get; set; }
        public DateTime Date { get; set; }
        public string Personnel { get; set; }
        public bool Deviating { get; set; }
        public List<Param> Params { get; set; }
    }

    public class Param
    {
        public string name { get; set; }
        public string value { get; set; }
        public bool IsValid { get; set; }
        public string required { get; set; }
    }

}
