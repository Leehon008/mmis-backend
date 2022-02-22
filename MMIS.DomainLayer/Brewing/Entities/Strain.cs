using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class Strain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public DateTime Date { get; set; }
        public string BrewNumber { get; set; }
        public string Vessel { get; set; }
        public decimal DecanterCIP { get; set; }
        public decimal SpentGrainsMoisture { get; set; }
        public decimal SpentGrainsMass { get; set; }
        public decimal TotalStrainingTime { get; set; }
        public string CIPEffectiveness { get; set; }
        public decimal Throughput { get; set; }
        public decimal StrainingTemp { get; set; }
        public decimal VibroScreenSize { get; set; }
        //public string CIPEffectiveness { get; set; }
        public string Safety { get; set; }
        public string Attendant { get; set; }
    }
}
