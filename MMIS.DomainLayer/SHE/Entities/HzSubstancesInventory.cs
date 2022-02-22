using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class HzSubstancesInventory : EntityBase
    {
        [Required]
        public string Section { get;  set; }
        [Required]
        public string Product { get;  set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string CorrectMSDS { get; set; }
        [Required]
        public string Hazardous { get; set; }
        [Required]
        public string Dangerous { get; set; }
        [Required]
        public string MaxQuantity { get; set; }
        [Required]
        public string Uses { get; set; }
        [Required]

        public string Manufacturer { get; set; }
        public string createdBy { get; set; }
     



    }
}

    

