using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{
    public class WasteTracking : EntityBase
    {
        [Required]
        public string waste { get;  set; }
        [Required]
        public string collector { get;  set; }
        [Required]
        public string DateCollected { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string DisposalCost { get; set; }
        [Required]
        public string SellingPrice { get; set; }
        [Required]
        public string DisposalSite { get; set; }
        [Required]
        public string CreatedBy { get; set; }

 
        public string Plant { get; set; }


    }
}

    

