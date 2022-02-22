using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    //public class Utilities : Entitybase
    //{
    //    public DateTime Date { get; set; }
    //}

    public class WaterTreatment: Entitybase
    {
        public DateTime Date { get; set; }
        public decimal Chlorides { get; set; }
        public decimal TreatedWaterHaze { get; set; }
        public decimal TaintNetting { get; set; }
    }
    public class Boiler: Entitybase
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
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
    public class Vessel: Entitybase
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Hardness { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
    }
    public class Condenser: Entitybase
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
        public decimal Alc { get; set; }
    }
    public class CoolingTower: Entitybase
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal TDS { get; set; }
        public decimal pH { get; set; }
        public decimal Alc { get; set; }
    }
    public class Refridgeration: Entitybase
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal GlycolStrength { get; set; }
        public decimal FreezingPoint { get; set; }
    }
    public class Effluent: Entitybase
    {
        public DateTime Date { get; set; }
        public decimal pH { get; set; }
        public decimal TSS { get; set; }
        public decimal PV { get; set; }
        public decimal COD { get; set; }
    }

    public class Hotwell : Vessel
    {
    }

    public class Softner : Vessel
    {
    }
}
