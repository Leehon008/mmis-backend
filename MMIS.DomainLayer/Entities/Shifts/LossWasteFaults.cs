using MMIS.DomainLayer.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.Entities.Shifts
{
    public class LossWasteFaults
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int Id { get;  set; }
        public string LWId { get; private set;  }
        public string FaultNo { get; private set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public int ShiftStatus { get; set; }
        public double LostTime { get; set; }
        public string Reason1 { get; set; }
        public string Reason2 { get; set; }
        public string Reason3 { get; set; }
        public string Reason4 { get; set; }
        public string Reason5 { get; set; }
        public DateTime CreatedOn { get; private set; }
        public string ModifiedBy { get; set; }
        public virtual LossWasteJobCard LWJobCard { get; set; }

        public virtual LossWasteHeader LWHeader { get; set; }
        


    }
}

