using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class ChemicalCompatibility : EntityBase
    {
        [Required]
        public string Location { get;  set; }
        [Required]
        public string StorageGroup { get;  set; }
        [Required]
        public string Temperature { get; set; }
        [Required]
        public string AverageHumidity { get; set; }
        [Required]
        public string ChemicalName { get; set; }
       
        public string Plant { get; set; }
        [Required]
        public string PhysicalForm { get; set; }
        [Required]
        public string Toxic { get; set; }
        [Required]
        public string Corrosive { get; set; }

        [Required]
        public string Flammable { get; set; }

        [Required]
        public string Properties { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public string msds { get; set; }

        [Required]
        public string RouteOfExposure { get; set; }
        [Required]
        public string Hazard { get; set; }
        [Required]
        public string CompatibilityStatus { get; set; }
        [Required]
        public string recommendations { get; set; }

        [Required]
        public string responsibility { get; set; }
        [Required]
        public string ClosureStatus { get; set; }
        [Required] 


        public string CreatedBy { get; set; }
     



    }
}

    

