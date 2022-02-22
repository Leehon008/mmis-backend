using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Models
{
    public class UtilitiesDto : ModelBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<WaterTreatmentDto> WaterTreatment { get; set; }
        public virtual ICollection<BoilerDto> Boilers { get; set; }
        public virtual ICollection<VesselDto> Softner { get; set; }
        public virtual ICollection<CondenserDto> Condenser { get; set; }
        public virtual ICollection<CoolingTowerDto> CoolingTowerFVs { get; set; }
        public virtual ICollection<RefridgerationDto> Refridgeration { get; set; }
        public virtual ICollection<EffluentDto> Effluent { get; set; }
    }

    public class WaterTreatmentDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public decimal Chlorides { get; set; }
        public decimal TreatedWaterHaze { get; set; }
        public decimal TaintNetting { get; set; }
    }
    public class BoilerDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public decimal Hardness { get; set; }
        public decimal sulphites { get; set; }
        public decimal PAlk { get; set; }
        public decimal OHAlk { get; set; }
        public decimal MAlk { get; set; }
        public decimal Chlorides { get; set; }
        public decimal TDS { get; set; }
        public decimal Conductivity { get; set; }
        public decimal pH { get; set; }
    }
    public class VesselDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public string Type { get; set; }
        public decimal Hardness { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
    }
    public class CondenserDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
        public decimal Alc { get; set; }
    }
    public class CoolingTowerDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public string Type { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
        public decimal Alc { get; set; }
    }
    public class RefridgerationDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public decimal GlycolStrength { get; set; }
        public decimal FreezingPoint { get; set; }
    }
    public class EffluentDto
    {
        public int Id { get; set; }
        public UtilitiesDto UId { get; set; }
        public decimal pH { get; set; }
        public decimal TSS { get; set; }
        public decimal PV { get; set; }
        public decimal COD { get; set; }
    }
}
