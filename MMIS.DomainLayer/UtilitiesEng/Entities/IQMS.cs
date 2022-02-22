using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.UtilitiesEng.Entities
{
    public class IQMS : EntityBase
    {
        public string AssetTagCO2 { get; set; }
        public string CO2Taste { get; set; }
        public string CO2Smell { get; set; }
        public virtual ICollection<WaterParameters> WaterParameters { get; set; }
    }

    public class WaterParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public virtual IQMS PId { get; set; }
        public string Type { get; set; }
        public string AssetTag { get; set; }
        public decimal Hardness { get; set; }
        public decimal Sulphates { get; set; }
        public decimal HardnessAsCaCO3 { get; set; }
        public decimal AlkalinityAsCaCO3 { get; set; }
        public decimal AlkalinityAsOH { get; set; }
        public decimal MalkalinityCO3OH { get; set; }
        public decimal Chlorides { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
        public decimal Conductivity { get; set; }
        public decimal Micro { get; set; }
        public string Taste { get; set; }
    }
}
