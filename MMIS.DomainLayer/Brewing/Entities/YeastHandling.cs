using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.DomainLayer.Brewing.Entities
{
    public class YeastHandling
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
        public string Strain { get; set; }
        public decimal StorageTemp { get; set; }
        public decimal PitchingRate { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public decimal AdditionPoint { get; set; }
        public decimal MaxStorageTime { get; set; }
    }
}
