using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class WasteManagement : EntityBase
    {
        [Required]
        public string wasteIdentified { get;  set; }
       
        public string Plant { get; set; }
        [Required]
        public string wasteFormat { get;  set; }
        [Required]
        public string wasteType { get; set; }
        [Required]
        public string generalWaste { get; set; }
        [Required]
        public string hazardousWaste { get; set; }
        [Required]
        public string WasteClassification { get; set; }
        [Required]
        public string Volume { get; set; }
        [Required]
        public string wasteManagement { get; set; }
        [Required]

        public string disposalSite { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string wastePosition { get; set; }
     
        public string createdBy { get; set; }
     



    }
}

    

