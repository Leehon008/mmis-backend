using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMIS.DomainLayer.Quality.Entities
{
    public class Calibrations : Entitybase
    {
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Alcolyser> Alcolyser { get; set; }
        public virtual ICollection<PHMeter> pHMeter { get; set; }
        public virtual ICollection<Refractometer> Refractometer { get; set; }
        public virtual ICollection<Viscometer> Viscometer { get; set; }
    }

    public class Viscometer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        public virtual Calibrations C { get; set; }
        public string SpindleCleaning { get; set; }
        public string ViscometerStandard100 { get; set; }
        public string ViscometerStandard500 { get; set; }
    }

    public class Refractometer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        public virtual Calibrations C { get; set; }
        public string Cleaning { get; set; }
        public string Calibration { get; set; }

    }

    public class PHMeter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        public virtual Calibrations C { get; set; }
        public string ElectrodeCleaning { get; set; }
        public string BufferpH7 { get; set; }
        public string BufferpH4 { get; set; }
        public string BufferpH10 { get; set; }
        public string Comment { get; set; }

    }

    public class Alcolyser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        public virtual Calibrations C { get; set; }
        public string Water { get; set; }
        public string PreCalibration { get; set; }
        public string WaterandAirAdjustment { get; set; }
        public string AlcoholAdjustment { get; set; }
        public string Comment { get; set; }
    }

    public class Entitybase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Analyst { get; set; }

    }

    public class EntityBaseCOA : Entitybase
    {
        public DateTime DateOfDelivery { get; set; }
        public string Supplier { get; set; }
        public string BatchNo { get; set; }
        public string COA { get; set; }
    }
}
